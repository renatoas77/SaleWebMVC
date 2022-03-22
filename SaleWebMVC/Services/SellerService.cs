﻿using System;
using System.Collections.Generic;
using System.Linq;
using SaleWebMVC.Services.Exceptions;
using SaleWebMVC.Data;
using SaleWebMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace SaleWebMVC.Services
{
    public class SellerService
    {
        private readonly SaleWebMVCContext _context;

        public SellerService(SaleWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindlAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller obj)
        {
            if(!_context.Seller.Any(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
