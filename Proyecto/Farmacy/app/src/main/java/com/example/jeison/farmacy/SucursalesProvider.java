package com.example.jeison.farmacy;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jeison on 26/09/2017.
 */

public class SucursalesProvider {

    private static SucursalesProvider provider = new SucursalesProvider();
    public ArrayList<Sucursales> Items=new ArrayList<Sucursales>();

    public SucursalesProvider(){

    }

    public static SucursalesProvider getInstance() {
        return provider;
    }
}
