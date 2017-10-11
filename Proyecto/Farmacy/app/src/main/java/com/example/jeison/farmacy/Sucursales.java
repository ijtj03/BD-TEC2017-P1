package com.example.jeison.farmacy;

/**
 * Created by Jeison on 26/09/2017.
 */

public class Sucursales {
    public String mName;
    public String mLocation;
    public String mAddress;

    public Sucursales(String name,String location,String Address){
        mName=name;
        mLocation=location;
        mAddress=Address;
    }

    public String toString(){
        return "Sucursal{Name:"+mName+",Location:"+mLocation+",Address:"+mAddress+"}";
    }
}
