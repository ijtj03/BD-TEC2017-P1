package com.example.jeison.farmacy;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Jeison on 04/10/2017.
 */

public class HistorialAdapter extends RecyclerView.Adapter<HistorialAdapter.ViewHolder>{

    private List<Historial> mItems;

    public HistorialAdapter(List<Historial> items){
        this.mItems=items;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.history_item, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        Historial item=mItems.get(position);
        holder.mItem=item;
        holder.mFecha.setText(item.mFecha);
        holder.mPadecimientos.setText(item.mPadecimientos);
    }

    @Override
    public int getItemCount() {
        return mItems.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        public final View mView;
        public final TextView mFecha;
        public final TextView mPadecimientos;
        public Historial mItem;

        public ViewHolder(View view) {
            super(view);
            mView = view;
            mFecha = (TextView) view.findViewById(R.id.fecha);
            mPadecimientos = (TextView) view.findViewById(R.id.padecimientos);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mFecha.getText() + "'";
        }
    }
}
