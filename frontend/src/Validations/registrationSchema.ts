import * as yup from "yup"

const registrationSchema = yup.object({
    firstname: yup
        .string()
        .required("firstname cannot be empty")
        .min(4, "firstname must be at least 6 characters")
        .max(20, "firstname must be maximum 20 characters"),
    lastname: yup
        .string()
        .required("lastname cannot be empty")
        .min(4, "lastname must be at least 6 characters")
        .max(20, "lastname must be maximum 20 characters"),
    email: yup
        .string().email().required("email cannot be empty"),
    phonenumber: yup
        .string()
        .required("phonenumber cannot be empty")
        .min(10, "phonenumber must be at least 10 degits")
        .max(20, "phonenumber must be maximum 20 degits"),
    password: yup
        .string()
        .required("password cannot be empty")
        .min(5, "username must be at least 8 characters")
        .max(20, "username must be maximum 20 characters")
        .matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)/),
    confirm: yup.string()
        .required("password cannot be empty")
        .oneOf([yup.ref("password")], "Password does not match"),
    avatar: yup.string()
        .required("Avatar can 't be empty"),
    shippingAddress: yup
        .string()
        .required("ShippingAdress cannot be empty")
        .min(6, "ShippingAdress must be at least 6 characters")
        .max(20, "ShippingAdress must be maximum 20 characters"),
        billingAddress: yup
        .string()
        .required("billingAddress cannot be empty")
        .min(6, "billingAddress must be at least 6 characters")
        .max(20, "billingAddress must be maximum 20 characters"),
})

export type registrationFormData = yup.InferType<typeof registrationSchema>
export default registrationSchema