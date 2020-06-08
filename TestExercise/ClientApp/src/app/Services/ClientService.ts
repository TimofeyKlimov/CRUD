import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Client } from "../model/client";

@Injectable()
export class ClientService{
constructor(private http:HttpClient){}

public getUsers(){
    return this.http.get("http://localhost:5000/api/get")
}


public updateUser(client:Client){
    const headers = new HttpHeaders().set("Content-Type","application/json");
    return this.http.post("http://localhost:5000/api/update",JSON.stringify(client),{headers:headers});
}

}