using NUnit.Framework;
using System;

namespace Csg.Test
{
	[TestFixture]
	public class VolumeTests
    {
		[Test]
		public void EmptySolid_HasZeroVolume()
		{
			const double expected = 0;

			var target = new Solid();
			var actual = target.ComputeVolume();

			Assert.AreEqual (expected, actual);
		}

		[Test]
		public void VolumeOfUnitCube_Is1UnitCubed()
		{
			// volume of unit cube is 1 unit^3 
			const double expected = 1;

			var target = Solids.Cube(1);
			var actual = target.ComputeVolume();

			Assert.AreEqual(expected, actual, 1e-15);
		}

		[Test]
		public void VolumeOfCube_IsWidthByHeightByDepth()
		{
			// volume of cube is w*h*d unit^3 
			var width = 30.65;
			var height = 24.17;
			var depth = 75.3;

			var expected = width * height * depth;

			var target = Solids.Cube(new Vector3D(width, height, depth));
			var actual = target.ComputeVolume();

			Assert.AreEqual(expected, actual, 1e-16);
		}

		[Test]
		public void VolumeOfSphere_LowResolution()
		{
			// volume of sphere is (4*PI*r^3)/3.0 unit^3
			double r = 3.4;

			var expected = 4 * Math.PI * r * r * r / 3.0;

			var options = new SphereOptions {
				Radius = r,
				Resolution = 32
			};
			
			var target = Solids.Sphere(options);
			var actual = target.ComputeVolume();

			Assert.AreEqual(expected, actual, 10);
		}

		[Test]
		public void VolumeOfSphere_HighResolution()
		{
			// volume of sphere is (4*PI*r^3)/3.0 unit^3
			double r = 3.4;

			var expected = 4 * Math.PI * r * r * r / 3.0;

			var options = new SphereOptions {
				Radius = r,
				Resolution = 1024
			};
			
			var target = Solids.Sphere(options);
			var actual = target.ComputeVolume();

			Assert.AreEqual(expected, actual, 1e-2);
		}

		[Test]
		public void VolumeOfCylinder_LowResolution()
		{
			// volume of cylinder is PI*r^2*h unit^3
			var r = 5.9;
			var h = 2.1;

			var expected = Math.PI * r * r * h;

			var options = new CylinderOptions {
				RadiusStart = r,
				RadiusEnd = r,
				Start = new Vector3D (0, 0, 0),
				End = new Vector3D (0, h, 0),
				Resolution = 32
			};

			var target = Solids.Cylinder(options);
			var actual = target.ComputeVolume();

			Assert.AreEqual(expected, actual, 10);
		}    

		[Test]
		public void VolumeOfCylinder_HighResolution()
		{
			// volume of cylinder is PI*r^2*h unit^3
			var r = 5.9;
			var h = 2.1;

			var expected = Math.PI * r * r * h;

			var options = new CylinderOptions {
				RadiusStart = r,
				RadiusEnd = r,
				Start = new Vector3D (0, 0, 0),
				End = new Vector3D (0, h, 0),
				Resolution = 1024
			};

			var target = Solids.Cylinder(options);
			var actual = target.ComputeVolume();

			Assert.AreEqual(expected, actual, 1e-2);
		}        
    }
}
