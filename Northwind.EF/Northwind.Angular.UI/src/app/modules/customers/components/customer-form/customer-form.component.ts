import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DbConnectionService } from '../../services/db-cust-connection.service';

import { CustomerModel } from '../..//models/CustomerModel';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-customer-form',
  templateUrl: './/customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})

export class CustomerFormComponent implements OnInit {

  err = null;
  isLoading = false;
  modalRef: BsModalRef;
  formValue: FormGroup;
  customerModel : CustomerModel = new CustomerModel;

  showAdd!: boolean;
  showUpdate!: boolean;

  minLengthAllFields: number = 4;

  maxLengthCompanyName: number = 40;
  maxLengthContactNameAndTitle: number = 30;
  maxLengthCity: number = 15;

  minLengthPhone: number = 8;
  maxLengthPhone: number = 24;

  public customers: Array<CustomerModel> = [];

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

    this.getCustomers();

    this.formValue = this.fb.group({
      CompanyName : ['', [Validators.required, Validators.minLength(this.minLengthAllFields),
        Validators.maxLength(this.maxLengthCompanyName)]],
      ContactName : ['', [Validators.required, Validators.minLength(this.minLengthAllFields),
        Validators.maxLength(this.maxLengthContactNameAndTitle)]],
      ContactTitle : ['', [Validators.minLength(this.minLengthAllFields),
        Validators.maxLength(this.maxLengthContactNameAndTitle)]],
      City : ['', [Validators.minLength(this.minLengthAllFields),
        Validators.maxLength(this.maxLengthCity)]],
      Phone : ['', [Validators.required, Validators.minLength(this.minLengthPhone),
        Validators.maxLength(this.maxLengthPhone)]]
    })
  }

  getCustomers(){

    this.isLoading = true;
    this.apiService.getAllCustomers()
    .subscribe(res => {

      this.isLoading = false;
      this.customers = res;

    },
    err => {

      this.isLoading = false;
      this.err = err.message
      this.toastrService.error('Error getting list - ' + err.message)
    });
  }

  insertCustomerDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.customerModel.CompanyName = this.formValue.value.CompanyName;
    this.customerModel.ContactName = this.formValue.value.ContactName;
    this.customerModel.ContactTitle = this.formValue.value.ContactTitle;
    this.customerModel.City = this.formValue.value.City;
    this.customerModel.Phone = this.formValue.value.Phone;

    this.apiService.addCustomer(this.customerModel)
    .subscribe(res =>{

      this.formValue.reset();
      this.toastrService.success('New Customer added!')
      this.getCustomers();

    },
    err => {
      this.err = err.message
      this.toastrService.error('Error to create a new Customer - ' + err.message)
    });
  }

  onEdit(customer: CustomerModel){

    this.showAdd = false;
    this.showUpdate = true;

    this.customerModel.CustomerID = customer.CustomerID;
    this.formValue.controls['CompanyName'].setValue(customer.CompanyName)
    this.formValue.controls['ContactName'].setValue(customer.ContactName)
    this.formValue.controls['ContactTitle'].setValue(customer.ContactTitle)
    this.formValue.controls['City'].setValue(customer.City)
    this.formValue.controls['Phone'].setValue(customer.Phone)
  }

  updateCustomerDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.customerModel.CompanyName = this.formValue.value.CompanyName;
    this.customerModel.ContactName = this.formValue.value.ContactName;
    this.customerModel.ContactTitle = this.formValue.value.ContactTitle;
    this.customerModel.City = this.formValue.value.City;
    this.customerModel.Phone = this.formValue.value.Phone;

    this.apiService.updateCustomer(this.customerModel, this.customerModel.CustomerID)
    .subscribe( res =>{
      this.toastrService.success('Successful Customer update.')
      this.getCustomers();

    },
    err =>{
      this.err = err.message
      this.toastrService.error('Update error - ' + err.message)
    });
  }

  deleteCustomer(customer: CustomerModel) {
    Swal.fire({
      title: 'Confirm',
      html: `Are you sure you want to delete?: <b>${ customer.CompanyName }</b>?`,
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
        this.apiService.deleteCustomer(customer.CustomerID).subscribe({
          next: res => {
            this.getCustomers();
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
