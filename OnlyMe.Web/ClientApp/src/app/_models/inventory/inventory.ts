import { Product } from '../product/product';

export interface Inventory extends base<number> {
    code:string,
    productId:number,
    invoiceId:number,
    purchasingprice:number,
    expectedSellingPrice:number,
    product:Product
}