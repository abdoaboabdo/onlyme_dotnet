import { Inventory } from '../inventory/inventory';
import { Store } from '../store/store';
import { Vendor } from '../vendor/vendor';

export interface VendorInvoice extends base<number> {
    code:string,
    vendorId:number,
    storeId:number,
    dateTime:Date,
    vendor:Vendor,
    store:Store
    inventories:Inventory[]
}