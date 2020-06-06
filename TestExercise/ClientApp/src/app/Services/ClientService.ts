import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ClientService{
constructor(private http:HttpClient){}

public getUsers(){
    return this.http.get("http://localhost:53037/api/get")
}
}