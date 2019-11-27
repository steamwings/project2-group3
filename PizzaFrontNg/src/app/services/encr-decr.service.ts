import { Injectable } from '@angular/core';
import * as CryptoJS from 'crypto-js';


@Injectable({
  providedIn: 'root'
})
export class EncrDecrService {

  constructor() { }

  private hash(pwd: string, salt: string) : string{
    let swords: CryptoJS.LibWordArray = CryptoJS.enc.Base64.parse(salt);
    let pwords: CryptoJS.LibWordArray = CryptoJS.enc.Utf8.parse(pwd);
    var hexStr = CryptoJS.enc.Hex.stringify(pwords) + CryptoJS.enc.Hex.stringify(swords);
    return CryptoJS.SHA256(CryptoJS.enc.Hex.parse(hexStr)).toString(CryptoJS.enc.Base64);
  }

  set(password){
    let saltWords = CryptoJS.lib.WordArray.random(128/8);
    let salt = CryptoJS.enc.Base64.stringify(saltWords);
    let hash = this.hash(password, salt);
    return {"salt" : salt, "hash": hash};
  }

  setLogin(password, salt){
    return this.hash(password, salt);
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
