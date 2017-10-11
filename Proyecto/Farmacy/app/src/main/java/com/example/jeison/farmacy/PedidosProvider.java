package com.example.jeison.farmacy;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jeison on 03/10/2017.
 */

public class PedidosProvider {
    public ArrayList<Pedidos> pedidoses=new ArrayList<Pedidos>();
    public static PedidosProvider provider=new PedidosProvider();

    public PedidosProvider(){
        pedidoses.add(new Pedidos("6423","Fishel","16/02/2020"));
        pedidoses.add(new Pedidos("6654","Fishel","16/10/2020"));
        pedidoses.add(new Pedidos("6326","Fishel","16/08/2020"));
        pedidoses.add(new Pedidos("6585","Fishel","16/07/2020"));
        pedidoses.add(new Pedidos("6456","Fishel","16/06/2020"));
    }

    public static PedidosProvider getinstance(){
        return provider;
    }
}
