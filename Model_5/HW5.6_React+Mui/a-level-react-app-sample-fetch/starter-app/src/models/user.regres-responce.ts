import { IUser } from "./user.model";
import { IUserSupport } from "./user.support";

export interface IUserRegresResponce{
    data: IUser
    support: IUserSupport
}