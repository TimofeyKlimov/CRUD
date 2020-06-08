import {Component, ViewChild, ElementRef} from '@angular/core';
import { Client } from '../model/client';
@Component({
    templateUrl:'addclient.component.html'
})
export class AddClientComponent{
    constructor(){
        this.client = new Client();
    }
    @ViewChild('select',{static:false}) select:ElementRef;
    client:Client;
    
    public Add():void{
        this.client.ClientType = this.select.nativeElement.value;
    }

} 