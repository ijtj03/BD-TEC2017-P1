package com.example.jeison.farmacy;

import android.content.Context;
import android.content.Intent;
import android.support.v4.app.Fragment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import java.util.ArrayList;

public class PedidosFragment extends Fragment {

    public OnListener mListener;
    public RecyclerView mPedidos;
    private Context mContext;

    public PedidosFragment(){}

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        mListener=new OnListener();



    }
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState){
        View view = inflater.inflate(R.layout.activity_pedidos, container, false);
        mContext=view.getContext();
        mPedidos= (RecyclerView) view.findViewById(R.id.recycler);
        mPedidos.setLayoutManager(new LinearLayoutManager(mContext,LinearLayoutManager.VERTICAL,false));
        mPedidos.setAdapter(new ListPedidosAdapter(PedidosProvider.getinstance().pedidoses,mListener));

        return view;
    }

    public class OnListener{
        public void onListenerAction(Pedidos item){
            ArrayList<Medicinas> lista=new ArrayList<Medicinas>();
            Intent intent=new Intent(mContext,PedidosConfigActivity.class);
            intent.putExtra("medicinas",lista.toString());
            startActivity(intent);
        }
    }
}
