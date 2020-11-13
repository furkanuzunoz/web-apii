using programind.dal;
using programing.API.attiribut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace programing.API.Properties
{
    
    public class TableController : ApiController
    {
        TableDal Tabledall = new TableDal();

        public HttpResponseMessage Get()
        {
            var table = Tabledall.GETalltable();
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public HttpResponseMessage Get(int id)
        {
            var table = Tabledall.gettablebyid(id);
            if(table == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "BÖYLE BİR KAYIT BULUNAMADI...");
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        public HttpResponseMessage Post(Table_1 table)
        {
            if (ModelState.IsValid)
            {
                var createdata = Tabledall.createtable(table);
                return Request.CreateResponse(HttpStatusCode.Created, createdata);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"invalid sintaxxxx");

        }
        public HttpResponseMessage Put(int id ,Table_1 table)
        {

            // kayıtlı id yoksa
            
            
                if (Tabledall.kayitvarmi(id) == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "kayıt bulunamadı ....");
                }
                // girilen datalar uyuşmuyorsa
                else if (ModelState.IsValid == false)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "uyumlu değiş");
                }
                //ok
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Tabledall.updatetable(id, table));
                }
            
            
            

        }
        public HttpResponseMessage delete(int id)
        {
            // girilen id'de kayıt yoksa
            if (Tabledall.kayitvarmi(id)==false) {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "girilen id'ye dair kayıt bulnamadı....");
            }
            // ok
            else
            {
                Tabledall.delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent );
            }

        }

    }
}
