import { Products } from "../../Types/Products";
import axios, { AxiosError } from "axios";

import { PayloadAction, createAsyncThunk, createSlice } from "@reduxjs/toolkit"

const initialState: {
    products: Products[],
    loading: boolean,
    error: string
} = {
    products:[],
    loading: false,
    error: ""
}

export const getAllProducts = createAsyncThunk(
    "getAllProducts",
    async () => {
        try {         
            const result = await axios.get<Products[]>("https://ecomercebadfad.azurewebsites.net/api/v1/products")
            return result.data
        }catch (e) {
            const error = e as AxiosError
            return error
        }
    }
)

export const getProductById = createAsyncThunk(
    "getProductById", async (productId: string, { rejectWithValue}) => {
        try {         
            const result = await axios.get<Products>(`https://ecomercebadfad.azurewebsites.net/api/v1/products/${productId}`)
            return result.data
        }catch (e) {
            const error = e as AxiosError
            return rejectWithValue(error.message)
        }
    }
)

const productSlice = createSlice({
    name: "product",
    initialState,
    reducers: {
    //     sortByCategory: (state, action:PayloadAction<"asc"|"desc">) => {
    //     if (action.payload === "asc") {
    //         state.products.sort((a,b) => a.category.name.localeCompare(b.category.name))
    //     }else {
    //         state.products.sort((a,b) => b.category.name.localeCompare(a.category.name))
    //     }
    //   },
        sortByPrice: (state, actoion: PayloadAction<"low"|"high">) => {
            if (actoion.payload === "low") {
                state.products.sort((a,b) => a.Price - b.Price)
            }else {
                state.products.sort((a,b) => b.Price - a.Price)
            }  
          },
          cleanUpProducts: () => {
            return initialState
          }
    },
    extraReducers: (build) => {
        build
        .addCase(getAllProducts.rejected, (state, action) => {
            state.loading = false
            state.error = "Cannot fetch data"
        })
        .addCase(getAllProducts.pending, (state, action) => {
            state.loading = true
        })
        .addCase(getAllProducts.fulfilled, (state, action) => {
            if (action.payload instanceof AxiosError) {
                state.error = action.payload.message
            }else {
            state.products = action.payload
            }
            state.loading = false
        })
    }
})

const productReducer = productSlice.reducer
export const { sortByPrice, cleanUpProducts} = productSlice.actions
export default productReducer