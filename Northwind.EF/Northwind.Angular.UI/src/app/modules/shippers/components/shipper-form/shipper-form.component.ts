import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DbConnectionService } from '../../services/db-connection.service';


import { ShipperModel } from '../../models/ShipperModel';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-shipper-form',
  templateUrl: './shipper-form.component.html',
  styleUrls: ['./shipper-form.component.css']
})

export class ShipperFormComponent implements OnInit {

  err = null;
  isLoading = false;
  modalRef: BsModalRef;
  formValue: FormGroup;
  shipperObj : ShipperModel = new ShipperModel;

  mostrarAdd!: boolean;
  mostrarUpdate!: boolean;

  public listShippers: Array<ShipperModel> = [];

  constructor(private httpclient:     HttpClient,
              private apiService:     DbConnectionService,
              private modalService:   BsModalService,
              private fb:             FormBuilder,
              private toastrService:  ToastrService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template,{ backdrop: 'static', keyboard: false });
  }

  notValidField(campo: string){

    return this.formValue.controls[campo].errors
        && this.formValue.controls[campo].touched;
  }

  ngOnInit() {

    this.getShippers();

    this.formValue = this.fb.group({
      companyName : ['', [Validators.required, Validators.minLength(4), Validators.maxLength(40)]],
      phone : ['', [Validators.required, Validators.minLength(10), Validators.maxLength(20)]]
    })
  }

  getShippers(){

    this.isLoading = true;
    this.apiService.getAllShippers()
    .subscribe(res => {

      this.isLoading = false;
      this.listShippers = res;

    },
    err => {

      this.isLoading = false;
      this.err = err.message
      this.toastrService.error('Error al intentar obtener listado de Shippers - ' + err.message)
    });
  }

  insertShipperDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.shipperObj.CompanyName = this.formValue.value.CompanyName;
    this.shipperObj.Phone = this.formValue.value.Phone;

    this.apiService.addShipper(this.shipperObj)
    .subscribe(res =>{

      this.formValue.reset();
      this.toastrService.success('Se cargó correctamente el Shipper')
      this.getShippers();

    },
    err => {
      this.err = err.message
      this.toastrService.error('Error al cargar el Shipper - ' + err.message)
    });
  }



  onEdit(shipper: any){

    this.mostrarAdd = false;
    this.mostrarUpdate = true;

    this.shipperObj.ShipperId = shipper.ShipperId;
    this.formValue.controls['CompanyName'].setValue(shipper.CompanyName)
    this.formValue.controls['Phone'].setValue(shipper.Phone)
  }

  updateShipperDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.shipperObj.CompanyName = this.formValue.value.CompanyName;
    this.shipperObj.Phone = this.formValue.value.Phone;

    this.apiService.updateShipper(this.shipperObj, this.shipperObj.ShipperId)
    .subscribe( res =>{
      this.toastrService.success('Se actualizaron correctamente los datos')
      this.getShippers();

    },
    err =>{
      this.err = err.message
      this.toastrService.error('Error al intentar actualizar los datos - ' + err.message)
    });
  }

  deleteShipper(shipper: any){

    if(window.confirm('¿Está seguro que desea eliminar el registro?')){
      this.apiService.deleteShipper(shipper.shipperID)
      .subscribe(res =>{
        this.toastrService.success('Se eliminó correctamente el Shipper')
        this.getShippers();
      },
      err => {
        this.err = err.message
        this.toastrService.error('Error al intentar eliminar el Shipper - ' + err.message)
      });
    }
  }

  clickBtnAdd(){
    this.formValue.reset();
    this.mostrarAdd = true;
    this.mostrarUpdate = false;
  }

}

