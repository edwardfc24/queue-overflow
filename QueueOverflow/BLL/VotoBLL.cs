using QueueOverflow.DAL;
using QueueOverflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueueOverflow.BLL
{
    public class VotoBLL
    {
        public static Voto rowToDto(VotoDS.VotosRow row)
        {
            Voto objVoto = new Voto();
            objVoto.idVoto = row.idVoto;
            objVoto.intEstado = row.intEstado;
            objVoto.idRegistro = row.idRegistro;
            objVoto.flagTipoVoto = row.flagTipoVoto;
            objVoto.idUsuario = row.idUsuario;
            return objVoto;
        }
        public static List<Voto> getAllVotes()
        {
            List<Voto> listaVotos = new List<Voto>();
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            VotoDS.VotosDataTable dtVotos = objDataSet.GetAllVotes();

            foreach (VotoDS.VotosRow row in dtVotos)
            {
                Voto objVoto = rowToDto(row);
                listaVotos.Add(objVoto);
            }
            return listaVotos;
        }
        public static Voto getVoteByID(int idVote)
        {
            Voto objVoto = new Voto();
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            VotoDS.VotosDataTable dtVotos = objDataSet.GetVoteByID(idVote);
            if (dtVotos.Count > 0)
            {
                objVoto = rowToDto(dtVotos[0]);
                return objVoto;
            }
            return null;
        }
        public static List<Voto> getVotesByIDRegisterTyperRegister(int register, int type)
        {
            List<Voto> listaVotos = new List<Voto>();
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            VotoDS.VotosDataTable dtVotos = objDataSet.GetVoteByIDRegisterTypeRegister(register, type);
            foreach (VotoDS.VotosRow row in dtVotos)
            {
                Voto objVoto = rowToDto(row);
                listaVotos.Add(objVoto);
            }
            return listaVotos;
        }
        public static List<Voto> getVotesByIDUser(int idUser)
        {
            List<Voto> listaVotos = new List<Voto>();
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            VotoDS.VotosDataTable dtVotos = objDataSet.GetVoteByIDUser(idUser);
            foreach (VotoDS.VotosRow row in dtVotos)
            {
                Voto objVoto = rowToDto(row);
                listaVotos.Add(objVoto);
            }
            return listaVotos;
        }
        public static int insertVote(Voto vote)
        {
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            int? id = 0;
            objDataSet.InsertVote(ref id, vote.intEstado, vote.idRegistro, vote.flagTipoVoto, vote.idUsuario);
            return (int)id;
        }
        /*public static void updateVote(Voto vote)
        {
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            objDataSet.UpdateVote(vote.idVoto, vote.intEstado, vote.idRegistro, vote.flagTipoVoto, vote.idUsuario);
        }*/
        public static void deleteVote(int idVote)
        {
            QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter objDataSet = new QueueOverflow.DAL.VotoDSTableAdapters.VotosTableAdapter();
            objDataSet.DeleteVote(idVote);
        }
    }
}