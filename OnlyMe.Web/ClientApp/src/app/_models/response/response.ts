export interface Response<Base>{
    isSuccess:boolean,
    message:string,
    additionalInfo:string,
    data:Base
}