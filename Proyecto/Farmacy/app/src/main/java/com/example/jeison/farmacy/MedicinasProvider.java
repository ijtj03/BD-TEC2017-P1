package com.example.jeison.farmacy;

import java.util.ArrayList;

/**
 * Created by Jeison on 30/09/2017.
 */

public class MedicinasProvider {
    private static MedicinasProvider provider = new MedicinasProvider();
    public ArrayList<Medicinas> Items=new ArrayList<Medicinas>();

    public MedicinasProvider(){
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","0"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","1"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","2"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","3"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","4"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","5"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","6"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","7"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","8"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","9"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","10"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","11"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","12"));
        Items.add(new Medicinas("Acetaminofen","100","Calle 2, avenida 6","5","13"));
    }

    public static MedicinasProvider getInstance() {
        return provider;
    }
}

