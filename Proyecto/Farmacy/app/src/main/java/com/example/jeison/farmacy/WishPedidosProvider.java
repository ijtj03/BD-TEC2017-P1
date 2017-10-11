package com.example.jeison.farmacy;

import java.util.ArrayList;

/**
 * Created by Jeison on 02/10/2017.
 */

public class WishPedidosProvider {
    public static WishPedidosProvider pedidosProvider=new WishPedidosProvider();

    ArrayList<Medicinas> medicinases=new ArrayList<Medicinas>();

    public WishPedidosProvider(){}

    public void addMedicina(Medicinas item){
        medicinases.add(item);
    }

    public void delMedicina(Medicinas item){
        medicinases.remove(item);
    }

    public static WishPedidosProvider getInstance() {
        return pedidosProvider;
    }
}
