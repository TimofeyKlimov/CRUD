import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Client } from "../model/client";

@Injectable()
export class ClientService{
constructor(private http:HttpClient){}

public getUsers(){
    return this.http.get("http://localhost:53037/api/get")
}


public updateUser(client:Client){
    const headers = new HttpHeaders().set("Content-Type","application/json");
    return this.http.post("http://localhost:53037/api/update",JSON.stringify(client),{headers:headers});
}

public createUser(client:Client){
    const headers = new HttpHeaders().set("Content-Type","application/json");
    return this.http.post("http://localhost:53037/api/create",JSON.stringify(client),{headers:headers});
}

public deleteUser(client:Client){
    const headers = new HttpHeaders().set("Content-Type","application/json");
    return this.http.post("http://localhost:53037/api/delete",JSON.stringify(client),{headers:headers});
}
}