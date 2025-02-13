﻿using OpenBench.Data;
using OpenBench.Models;
using OpenBench.Repositories;
using Microsoft.EntityFrameworkCore;

namespace OpenBench.Repositories
{
    public class ResultRepository : CoreRepository<Result, BenchWebContext>
    {
        private readonly BenchWebContext _dbContext;
        private readonly ILogger<ResultRepository> _logger;

        public ResultRepository(BenchWebContext context, ILogger<ResultRepository> logger) : base(context, logger)
        {
            _dbContext = context;
            _logger = logger;
        }
        public async Task<List<Result>> FilterByAverageFps(double number)
        {
            var results = await _dbContext.Results.ToListAsync();
            var filteredResults = results.Where(x => x.AverageFrameRate == number).ToList();
            return filteredResults;

        }
        public async Task<List<Result>> FilterByMinimumFrameRate(double number)
        {
            var results = await _dbContext.Results.ToListAsync();
            var filteredResults = results.Where(x => x.MinimumFrameRate == number).ToList();
            return filteredResults;

        }
        public async Task<List<Result>> FilterByMaximumFrameRate(double number)
        {
            var results = await _dbContext.Results.ToListAsync();
            var filteredResults = results.Where(x => x.MaximumFrameRate == number).ToList();
            return filteredResults;

        }
        public async Task<List<Result>> FilterByOnePercentLow(double number)
        {
            var results = await _dbContext.Results.ToListAsync();
            var filteredResults = results.Where(x => x.OnePercentLow == number).ToList();
            return filteredResults;

        }
        public async Task<List<Result>> FilterByZeroOnePercentLow(double number)
        {
            var results = await _dbContext.Results.ToListAsync();
            var filteredResults = results.Where(x => x.ZeroOnePercentLow == number).ToList();
            return filteredResults;

        }
    }
}
