import { Component, Renderer2, ElementRef, ViewChild, TemplateRef, OnInit } from '@angular/core';
import { Client } from '../model/client';
import { ClientService } from '../Services/ClientService';

@Component({
    templateUrl:"clients.component.html",
    providers:[ClientService]
})

export class ChildComponent implements OnInit{
    constructor(private renderer:Renderer2,
                private elementref:ElementRef,
                private clientService:ClientService)
    {
        
    }
    ngOnInit(): void {
        this.loadClients()
    }

    public clients:Client[]
    @ViewChild('editTemplate',{static:false}) editTemplate:TemplateRef<any>;
    @ViewChild('readOnlyTemplate',{static:false}) readOnlyTemplate:TemplateRef<any>

     loadTemplate(client:Client){
        return this.readOnlyTemplate;
    }

    loadClients(){
        this.clientService.getUsers().subscribe((s:any) =>{
            this.clients = s;
        })
    }
}