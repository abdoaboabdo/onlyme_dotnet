import { Variety } from '../variety/variety';

export interface Category extends base<number>{
    name:string,
    variety:Variety[]
}