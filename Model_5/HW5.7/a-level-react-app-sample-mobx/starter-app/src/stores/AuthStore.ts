import { makeAutoObservable} from "mobx";
import * as authApi from "../api/modules/auth";
import * as postRegistrationApi from "../api/modules/postRegistration";

class AuthStore {
    token = "";
    id = 0;

    constructor() {
        makeAutoObservable(this);
    }

    async login(email: string, password: string) {
        const result = await authApi.login({email, password});
        this.token = result.token;
    }

    async registration(email: string, password: string){
        const result = await postRegistrationApi.registration({email, password});
        this.token = result.token;
        this.id = result.id;
    }

    logout(): void{
        this.token = "";
    }
}

export default AuthStore;