package com.example.jeison.farmacy;

import android.view.View;

/**
 * Created by Jeison on 30/09/2017.
 */

public class Medicinas {
    public String mName;
    public String mPrice;
    public String mDescripcion;
    public String mCantidad;
    public String mPosition;
    public int mPPostion;
    public View mViewm;

    public Medicinas(String name,String price,String descripcion,String cantidad,String position){
        this.mName=name;
        this.mCantidad=cantidad;
        this.mDescripcion=descripcion;
        this.mPrice=price;
        this.mPosition=position;
        this.mPPostion=0;
        mViewm=null;
    }

    public String toString(){
        return "{\"mName\":\""+mName+"\",\"mPrice\":\""+mPrice+"\",\"mDescripcion\":\""+mDescripcion+"\",\"mCantidad\":\""+mCantidad+"\",\"mPosition\":\""+mPosition+"\"}";
    }
}
