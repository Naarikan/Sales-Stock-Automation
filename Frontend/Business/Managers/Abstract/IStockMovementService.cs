﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Business.Managers.Abstract
{
	public interface IStockMovementService
	{
		Task<List<StockMovementModel>> GetMovementsAsync();
		
	}
}
