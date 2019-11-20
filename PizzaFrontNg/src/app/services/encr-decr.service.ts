import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';


@Injectable({
  providedIn: 'root'
})
export class EncrDecrService {

  constructor() { }

  set(toHash){
    let salt = CryptoJS.lib.WordArray.random(128/8);
    let hash = CryptoJS.SHA256(toHash, salt);
    let stringhash= hash.toString(CryptoJS.enc.Base64)
    let stringsalt = CryptoJS.enc.Base64.stringify(salt)
    return {"salt" : stringsalt, "hash": stringhash};
  }

  setLogin(password){

    let hash = CryptoJS.SHA256(password);
    let stringhash = hash.toString(CryptoJS.enc.Base64);
    return stringhash


  }

  //The get method is use for decrypt the value.
  get(keys, value){
    var key = CryptoJS.enc.Utf8.parse(keys);
    var iv = CryptoJS.enc.Utf8.parse(keys);
    var decrypted = CryptoJS.AES.decrypt(value, key, {
        keySize: 128 / 8,
        iv: iv,
        mode: CryptoJS.mode.CBC,
        padding: CryptoJS.pad.Pkcs7
    });

    return decrypted.toString(CryptoJS.enc.Utf8);
  }
}
