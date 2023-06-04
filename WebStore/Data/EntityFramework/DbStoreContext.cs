using WebStore.Models;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Data.EntityFramework.Context;

public class DbStoreContext : DbContext
{
    DbSet<ClientModel>
}
