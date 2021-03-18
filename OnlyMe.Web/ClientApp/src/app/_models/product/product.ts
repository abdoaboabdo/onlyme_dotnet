import { Inventory } from '../inventory/inventory';
import { Variety } from '../variety/variety';

export interface Product extends base<number>{
    name:string,
    description:string,
    varietyId:number,
    variety:Variety,
    inventories : Inventory[]
}