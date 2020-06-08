import { Component, Renderer2, ElementRef, ViewChild, TemplateRef, OnInit } from '@angular/core';
import { Client } from '../model/client';
import { ClientService } from '../Services/ClientService';

@Component({
    templateUrl:"clients.component.html",
    providers:[ClientService]
})

export class ClientComponent implements OnInit{
    constructor(private renderer:Renderer2,
                private elementref:ElementRef,
                private clientService:ClientService)
    {
        
    }
    ngOnInit(): void {
        this.loadClients()
    }
    public editClient:Client
    public clients:Client[]
    public OneOfclientType;
    errirs:Error[]
    private clientType=["IndividualEntrepreneur","LegalEntity"]
    @ViewChild('editTemplate',{static:false}) editTemplate:TemplateRef<any>;
    @ViewChild('readOnlyTemplate',{static:false}) readOnlyTemplate:TemplateRef<any>
    @ViewChild('select',{static:false}) select;
     loadTemplate(client:Client){
        if(this.editClient != null && this.editClient === client)
        {
            return this.editTemplate
        }
        return this.readOnlyTemplate;
    }
    Edit(client:Client){
        this.editClient = client
        this.OneOfclientType = this.GetValue()

    }
    loadClients(){
        this.clientService.getUsers().subscribe((s:any) =>{
            this.clients = s;
        })
    }

    GetValue():any{
      let value = this.clientType.find(s => s != this.editClient.ClientType);
      return value;
    }

    Accept(){
       let type:string = this.select.nativeElement.value; 
       this.editClient.ClientType = type;
       this.clientService.updateUser(this.editClient).subscribe(s =>{
        this.editClient == null
        this.loadClients();
       }) 
    }


}