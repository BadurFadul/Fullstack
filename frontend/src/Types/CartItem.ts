import { Products } from "./Products"

export interface CartItem {
    Quantity: number
    ProductId:string
    ShoppingCartId: string
}

export interface CartItem2 {
    product: Products
    quantity: number
}