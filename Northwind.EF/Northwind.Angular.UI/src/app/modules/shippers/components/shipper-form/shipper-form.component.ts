import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DbConnectionService } from '../../services/db-connection.service';

import { ShipperModel } from '../../models/ShipperModel';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

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
  shipperModel : ShipperModel = new ShipperModel;

  showAdd!: boolean;
  showUpdate!: boolean;

  minLengthCompanyName: number = 4;
  maxLengthCompanyName: number = 40;

  minLengthPhone: number = 8;
  maxLengthPhone: number = 24;


  public shippers: Array<ShipperModel> = [];

  constructor(private httpclient:     HttpClient,
              private apiService:     DbConnectionService,
              private modalService:   BsModalService,
              private fb:             FormBuilder,
              private toastrService:  ToastrService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template,{ backdrop: 'static', keyboard: false });
  }

  notValidField(field: string){

    return this.formValue.controls[field].errors
        && this.formValue.controls[field].touched;
  }

  ngOnInit() {

    this.getShippers();

    this.formValue = this.fb.group({
      CompanyName : ['', [Validators.required, Validators.minLength(this.minLengthCompanyName),
         Validators.maxLength(this.maxLengthCompanyName)]],
      Phone : ['', [Validators.required, Validators.minLength(this.minLengthPhone),
         Validators.maxLength(this.maxLengthPhone)]]
    })
  }

  getShippers(){

    this.isLoading = true;
    this.apiService.getAllShippers()
    .subscribe(res => {

      this.isLoading = false;
      this.shippers = res;

    },
    err => {

      this.isLoading = false;
      this.err = err.message
      this.toastrService.error('Error getting list - ' + err.message)
    });
  }

  insertShipperDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.shipperModel.CompanyName = this.formValue.value.CompanyName;
    this.shipperModel.Phone = this.formValue.value.Phone;

    this.apiService.addShipper(this.shipperModel)
    .subscribe(res =>{

      this.formValue.reset();
      this.toastrService.success('New Shipper added!')
      this.getShippers();

    },
    err => {
      this.err = err.message
      this.toastrService.error('Error to create a new Shipper - ' + err.message)
    });
  }

  onEdit(shipper: ShipperModel){

    this.showAdd = false;
    this.showUpdate = true;

    this.shipperModel.ShipperID = shipper.ShipperID;
    this.formValue.controls['CompanyName'].setValue(shipper.CompanyName)
    this.formValue.controls['Phone'].setValue(shipper.Phone)
  }

  updateShipperDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.shipperModel.CompanyName = this.formValue.value.CompanyName;
    this.shipperModel.Phone = this.formValue.value.Phone;

    this.apiService.updateShipper(this.shipperModel, this.shipperModel.ShipperID)
    .subscribe( res =>{
      this.toastrService.success('Successful Shippers update.')
      this.getShippers();

    },
    err =>{
      this.err = err.message
      this.toastrService.error('Update error - ' + err.message)
    });
  }

  deleteShipper(shipper: ShipperModel) {
    Swal.fire({
      title: 'Confirm',
      html: `Are you sure you want to delete?: <b>${ shipper.CompanyName }</b>?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'CONFIRM',
      cancelButtonText: 'CANCEL'
    }).then((result:any) => {
      if (result.value) {
        Swal.fire({
            title: 'Please wait...',
            showConfirmButton: false,
        });
        Swal.showLoading();
        this.apiService.deleteShipper(shipper.ShipperID).subscribe({
          next: res => {
            this.getShippers();
            Swal.close();
            setTimeout(function() {
            }, 4000);
          },
          error: err => {
            Swal.close();
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Error'
            });
          }
        });
      }
    });
  }

  clickBtnAdd(){
    this.formValue.reset();
    this.showAdd = true;
    this.showUpdate = false;
  }
}
