import { VendorInvoice } from '../vendorInvoice/vendorInvoice';

export interface Store extends base<number> {
    code:string,
    name:string,
    address:string,
    vendorInvoices:VendorInvoice[]
}