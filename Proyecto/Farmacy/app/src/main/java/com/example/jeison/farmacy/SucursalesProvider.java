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
     Items.add(new Sucursales("Fishel","Cartago","Calle 2, avenida 6"));
        Items.add(new Sucursales("La Bomba","San Jose","Calle 4, avenida 7"));
        Items.add(new Sucursales("Candelaria","Cartago","Calle 2, avenida 6"));
        Items.add(new Sucursales("La Bomba","Cartago","Calle 4, avenida 6"));
    }

    public static SucursalesProvider getInstance() {
        return provider;
    }
}
