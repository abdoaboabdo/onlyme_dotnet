import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './pagination.component';
import {WavesModule} from '../../../projects/ng-uikit-pro-standard/src/lib/free/waves';

@NgModule({
  declarations: [PaginationComponent],
  imports: [
    CommonModule,
    WavesModule
  ],
  exports: [PaginationComponent]
})
export class SharedModule { }
