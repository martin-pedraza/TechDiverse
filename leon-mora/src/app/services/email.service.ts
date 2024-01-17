import { Injectable } from '@angular/core';
import emailjs, { EmailJSResponseStatus } from '@emailjs/browser';


@Injectable({
  providedIn: 'root'
})
export class EmailService {

constructor() { }

  serviceId = "service_pp78cx9";

  async sendEmail(nombre:string,destinatario: string,aceptado: boolean){
    console.log("Send Email Service",nombre, destinatario,aceptado);

    if (destinatario != undefined ){
      let response;
      emailjs.init("htgc4YhVFZFRwDK-q")
      if(aceptado){
        response = await  emailjs.send(this.serviceId,"template_wxulywv",{
          user: nombre,
          reply_to: "restauranteleonmora@gmail.com",
          destinatario: destinatario,
          });
      }else{
        response = await emailjs.send(this.serviceId,"template_ukdmpnv",{
          user: nombre,
          destinatario: destinatario,
          reply_to: "restauranteleonmora@gmail.com",
          });
      }
    }else{
      console.log("No se ingreso un destinatario",nombre, destinatario,aceptado);
    }
  }

}
