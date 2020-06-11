import {Component, ViewChild, ElementRef} from '@angular/core';
import { Client } from '../model/client';
import { ClientService } from '../Services/ClientService';
import { Router } from '@angular/router';
@Component({
    templateUrl:'addclient.component.html',
    providers:[ClientService]
})
export class AddClientComponent{
    constructor(private clientService:ClientService,
                private router:Router){
        this.client = new Client();
    }
    @ViewChild('select',{static:false}) select:ElementRef;
    client:Client;
    
    public Add():void{
        this.client.ClientType = this.select.nativeElement.value;
        this.clientService.createUser(this.client)
                                .subscribe(s =>{
                                    this.router.navigate(['/'])
                                })
    }

} 