using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trivia;

namespace Data
{

    public class Repository { 
        private Context _ctx;

        public Repository(Context context)
        {
            _ctx = context;
        }

        public async Task CommitChanges()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task AddScore(Score score)
        {

            await _ctx.Scores.AddAsync(score);
            await CommitChanges();
        }

        public async Task<List<Score>> GetScoresAsync()
        {
            return await _ctx.Scores.OrderByDescending(x => x.UserScore).ToListAsync();
        }

        public async Task<List<Score>> GetScoresAsync(int top)
        {
            return await _ctx.Scores.OrderByDescending(x => x.UserScore).Take<Score>(top).ToListAsync();
        }
    }
}