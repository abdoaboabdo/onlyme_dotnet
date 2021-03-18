import { Category } from '../category/category';
import { Product } from '../product/product';

export interface Variety extends base<number>{
    name:string,
    categoryId:number,
    category:Category,
    products:Product[]
}