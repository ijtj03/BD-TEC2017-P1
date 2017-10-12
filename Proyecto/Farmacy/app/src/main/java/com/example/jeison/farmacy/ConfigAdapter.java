package com.example.jeison.farmacy;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Jeison on 03/10/2017.
 */

public class ConfigAdapter extends RecyclerView.Adapter<ConfigAdapter.ViewHolder> {

    private List<Medicinas> mMedicinas;
    private final PedidosConfigActivity.OnListener mListener;

    public ConfigAdapter(List<Medicinas> medicinases,PedidosConfigActivity.OnListener listener){
        this.mMedicinas=medicinases;
        this.mListener=listener;
    }

    public void delMedicina(Medicinas item){
        mMedicinas.remove(item);
        notifyDataSetChanged();
    }
    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.pedidos_item, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        Medicinas item = mMedicinas.get(position);
        holder.mItem = item;
        holder.mName.setText(item.mName);
        holder.mPrice.setText(item.mPrice);
        holder.mDescripcion.setText(item.mDescripcion);

        holder.mAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                mListener.onListenerAction(holder.mItem, holder.mView);
            }
        });
    }
    @Override
    public int getItemCount() {
        return mMedicinas.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        public final View mView;
        public final TextView mName;
        public final TextView mPrice;
        public final TextView mDescripcion;
        public final EditText mCantidad;
        public final Button mAdd;
        public Medicinas mItem;

        public ViewHolder(View view) {
            super(view);
            mView = view;
            mName = (TextView) view.findViewById(R.id.name);
            mPrice = (TextView) view.findViewById(R.id.price);
            mDescripcion= (TextView) view.findViewById(R.id.des);
            mAdd= (Button) view.findViewById(R.id.check_add);
            mCantidad= (EditText) view.findViewById(R.id.cantidad);
            mCantidad.setText("1");
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mName.getText() + "'";
        }
    }
}
