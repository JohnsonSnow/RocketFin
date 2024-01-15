import {Component, Inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialog, 
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose, 
} from '@angular/material/dialog';
import { DialogData, InvestmentsComponent } from '../investments/investments.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TransactionService } from '../services/transaction.service';


@Component({
  selector: 'app-purchase-shares',
  templateUrl: './purchase-shares.component.html',
  styleUrls: ['./purchase-shares.component.scss'],
})
export class PurchaseSharesComponent {

  share!: string;
  purchaseFormGroup!: FormGroup;


  constructor(
    @Inject(MAT_DIALOG_DATA) 
    public data: DialogData,
    public dialogRef: MatDialogRef<InvestmentsComponent>, 
    private formBuilder: FormBuilder, 
    private transactionService: TransactionService) {
    this.purchaseFormGroup = this.formBuilder.group({
      quantity: ['', Validators.required],
    });
  }


  onSubmit(){
    if (this.purchaseFormGroup.valid) {
      let data = {
        'symbol':this.data.share,
        'numberOfShares': this.purchaseFormGroup.value.quantity,
      }

      this.transactionService.purchaseShares(data).subscribe((data: any) => { 
        //this.investmentData = data.value.quoteResponse.result;;
        console.log(data)
       
       });
 
    }
  }
}
