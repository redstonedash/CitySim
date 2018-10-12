
public class World<T>
{
	private T[,,] world;
	
	public World (int width, int height, int depth, T filler)
	{
		this.world = new T[width, height, depth];
		this.Fill(filler);
	}
  
	private World (int width, int height, int depth)
	{
		this.world = new T[width, height, depth];
	}
  
	private void Fill (T filler)
	{
		for (var x = 0; x < Width(); x++)
		for (var y = 0; y < Height(); y++)
		for (var z = 0; z < Depth(); z++)
			Write(x, y, z, filler);
	}
	
	public World<T> Area (int x0, int y0, int z0, int x1, int y1, int z1)
	{
		var width  = x1 - x0 + 1;
		var height = y1 - y0 + 1;
		var depth  = z1 - z0 + 1;
		World<T> area = new World<T> (width, height, depth);
		
		for (var x = x0; x <= x1; x++)
		for (var y = y0; y <= y1; y++)
		for (var z = z0; z <= z1; z++)
			area.Write (x, y, z, Read (x, y, z));
		
		return area;
	}
	
	// Dimensions
	
	public int Depth ()
	{
		return this.world.GetLength(2);
	}
	
	public int Height ()
	{
		return this.world.GetLength(1);
	}
	
	public int Width ()
	{
		return this.world.GetLength(0);
	}
	
	// Side-effects
	
	public T Read (int x, int y, int z)
	{
		return this.world[x, y, z];
	}
	
	public void Write (int x, int y, int z, T val)
	{
		this.world[x, y, z] = val;
	}
}
