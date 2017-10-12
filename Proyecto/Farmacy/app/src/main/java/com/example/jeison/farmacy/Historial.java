package com.example.jeison.farmacy;

/**
 * Created by Jeison on 04/10/2017.
 */

public class Historial {
    public String mFecha;
    public String mPadecimientos;

    public Historial(String fecha,String padecimientos){
        this.mFecha=fecha;
        this.mPadecimientos=padecimientos;
    }

    public String toString(){
        return "{\"mFecha\":\""+this.mFecha+"\",\"mPadecimientos\":\""+mPadecimientos+"\"}";
    }
}
