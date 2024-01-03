namespace game_center_backend_cs.Infrastructure.Db;

public interface IOrmMapper<T, TU>
{
    public static abstract T ToDatabase(TU model);
    public static abstract TU FromDatabase(T model);
}