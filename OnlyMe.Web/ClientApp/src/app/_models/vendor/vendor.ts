import { VendorInvoice } from '../vendorInvoice/vendorInvoice';

export interface Vendor extends base<number>{
    name:string,
    email:string,
    mobileNumber:string,
    phoneNumber:string,
    addressDetails:string
    invoices:VendorInvoice[]
}