#region License
/* FNA - XNA4 Reimplementation for Desktop Platforms
 * Copyright 2009-2020 Ethan Lee and the MonoGame Team
 *
 * Released under the Microsoft Public License.
 * See LICENSE for details.
 */
#endregion

#region Using Statements
using System;
using System.Runtime.InteropServices;
#endregion

namespace Microsoft.Xna.Framework.Graphics
{
	[StructLayout(LayoutKind.Explicit)]
	internal struct GLCommand
	{
		[FieldOffset(0)]
		public int type;

		[FieldOffset(0)]
		public CreateEffectCMD		createEffect;
		[FieldOffset(0)]
		public CloneEffectCMD		cloneEffect;
		[FieldOffset(0)]
		public GenVertexBufferCMD	genVertexBuffer;
		[FieldOffset(0)]
		public GenIndexBufferCMD	genIndexBuffer;
		[FieldOffset(0)]
		public SetVertexBufferDataCMD	setVertexBufferData;
		[FieldOffset(0)]
		public SetIndexBufferDataCMD	setIndexBufferData;
		[FieldOffset(0)]
		public GetVertexBufferDataCMD	getVertexBufferData;
		[FieldOffset(0)]
		public GetIndexBufferDataCMD	getIndexBufferData;
		[FieldOffset(0)]
		public CreateTexture2DCMD	createTexture2D;
		[FieldOffset(0)]
		public CreateTexture3DCMD	createTexture3D;
		[FieldOffset(0)]
		public CreateTextureCubeCMD	createTextureCube;
		[FieldOffset(0)]
		public SetTextureData2DCMD	setTextureData2D;
		[FieldOffset(0)]
		public SetTextureData3DCMD	setTextureData3D;
		[FieldOffset(0)]
		public SetTextureDataCubeCMD	setTextureDataCube;
		[FieldOffset(0)]
		public GetTextureData2DCMD	getTextureData2D;
		[FieldOffset(0)]
		public GetTextureData3DCMD	getTextureData3D;
		[FieldOffset(0)]
		public GetTextureDataCubeCMD	getTextureDataCube;
		[FieldOffset(0)]
		public GenColorRenderbufferCMD	genColorRenderbuffer;
		[FieldOffset(0)]
		public GenDepthRenderbufferCMD	genDepthRenderbuffer;

		public const int CREATEEFFECT =		0;
		public const int CLONEEFFECT =			1;
		public const int GENVERTEXBUFFER =		2;
		public const int GENINDEXBUFFER =		3;
		public const int SETVERTEXBUFFERDATA =		4;
		public const int SETINDEXBUFFERDATA =		5;
		public const int GETVERTEXBUFFERDATA =		6;
		public const int GETINDEXBUFFERDATA =		7;
		public const int CREATETEXTURE2D =		8;
		public const int CREATETEXTURE3D =		9;
		public const int CREATETEXTURECUBE =		10;
		public const int SETTEXTUREDATA2D =		11;
		public const int SETTEXTUREDATA3D =		12;
		public const int SETTEXTUREDATACUBE =		13;
		public const int GETTEXTUREDATA2D =		14;
		public const int GETTEXTUREDATA3D =		15;
		public const int GETTEXTUREDATACUBE =		16;
		public const int GENCOLORRENDERBUFFER =	17;
		public const int GENDEPTHRENDERBUFFER =	18;

		public static readonly int Size = Marshal.SizeOf(typeof(GLCommand));

		public static void Execute(IGLDevice device, ref GLCommand cmd)
		{
			switch (cmd.type)
			{
				case CREATEEFFECT:
					cmd.createEffect.retval = device.CreateEffect(
						cmd.createEffect.effectCode
					);
					break;
				case CLONEEFFECT:
					cmd.cloneEffect.retval = device.CloneEffect(
						cmd.cloneEffect.cloneSource
					);
					break;
				case GENVERTEXBUFFER:
					cmd.genVertexBuffer.retval = device.GenVertexBuffer(
						cmd.genVertexBuffer.dynamic,
						cmd.genVertexBuffer.usage,
						cmd.genVertexBuffer.vertexCount,
						cmd.genVertexBuffer.vertexStride
					);
					break;
				case GENINDEXBUFFER:
					cmd.genIndexBuffer.retval = device.GenIndexBuffer(
						cmd.genIndexBuffer.dynamic,
						cmd.genIndexBuffer.usage,
						cmd.genIndexBuffer.indexCount,
						cmd.genIndexBuffer.indexElementSize
					);
					break;
				case SETVERTEXBUFFERDATA:
					device.SetVertexBufferData(
						cmd.setVertexBufferData.buffer,
						cmd.setVertexBufferData.offsetInBytes,
						cmd.setVertexBufferData.data,
						cmd.setVertexBufferData.dataLength,
						cmd.setVertexBufferData.options
					);
					break;
				case SETINDEXBUFFERDATA:
					device.SetIndexBufferData(
						cmd.setIndexBufferData.buffer,
						cmd.setIndexBufferData.offsetInBytes,
						cmd.setIndexBufferData.data,
						cmd.setIndexBufferData.dataLength,
						cmd.setIndexBufferData.options
					);
					break;
				case GETVERTEXBUFFERDATA:
					device.GetVertexBufferData(
						cmd.getVertexBufferData.buffer,
						cmd.getVertexBufferData.offsetInBytes,
						cmd.getVertexBufferData.data,
						cmd.getVertexBufferData.startIndex,
						cmd.getVertexBufferData.elementCount,
						cmd.getVertexBufferData.elementSizeInBytes,
						cmd.getVertexBufferData.vertexStride
					);
					break;
				case GETINDEXBUFFERDATA:
					device.GetIndexBufferData(
						cmd.getIndexBufferData.buffer,
						cmd.getIndexBufferData.offsetInBytes,
						cmd.getIndexBufferData.data,
						cmd.getIndexBufferData.startIndex,
						cmd.getIndexBufferData.elementCount,
						cmd.getIndexBufferData.elementSizeInBytes
					);
					break;
				case CREATETEXTURE2D:
					cmd.createTexture2D.retval = device.CreateTexture2D(
						cmd.createTexture2D.format,
						cmd.createTexture2D.width,
						cmd.createTexture2D.height,
						cmd.createTexture2D.levelCount,
						cmd.createTexture2D.isRenderTarget
					);
					break;
				case CREATETEXTURE3D:
					cmd.createTexture3D.retval = device.CreateTexture3D(
						cmd.createTexture3D.format,
						cmd.createTexture3D.width,
						cmd.createTexture3D.height,
						cmd.createTexture3D.depth,
						cmd.createTexture3D.levelCount
					);
					break;
				case CREATETEXTURECUBE:
					cmd.createTextureCube.retval = device.CreateTextureCube(
						cmd.createTextureCube.format,
						cmd.createTextureCube.size,
						cmd.createTextureCube.levelCount,
						cmd.createTextureCube.isRenderTarget
					);
					break;
				case SETTEXTUREDATA2D:
					device.SetTextureData2D(
						cmd.setTextureData2D.texture,
						cmd.setTextureData2D.format,
						cmd.setTextureData2D.x,
						cmd.setTextureData2D.y,
						cmd.setTextureData2D.w,
						cmd.setTextureData2D.h,
						cmd.setTextureData2D.level,
						cmd.setTextureData2D.data,
						cmd.setTextureData2D.dataLength
					);
					break;
				case SETTEXTUREDATA3D:
					device.SetTextureData3D(
						cmd.setTextureData3D.texture,
						cmd.setTextureData3D.format,
						cmd.setTextureData3D.level,
						cmd.setTextureData3D.left,
						cmd.setTextureData3D.top,
						cmd.setTextureData3D.right,
						cmd.setTextureData3D.bottom,
						cmd.setTextureData3D.front,
						cmd.setTextureData3D.back,
						cmd.setTextureData3D.data,
						cmd.setTextureData3D.dataLength
					);
					break;
				case SETTEXTUREDATACUBE:
					device.SetTextureDataCube(
						cmd.setTextureDataCube.texture,
						cmd.setTextureDataCube.format,
						cmd.setTextureDataCube.xOffset,
						cmd.setTextureDataCube.yOffset,
						cmd.setTextureDataCube.width,
						cmd.setTextureDataCube.height,
						cmd.setTextureDataCube.cubeMapFace,
						cmd.setTextureDataCube.level,
						cmd.setTextureDataCube.data,
						cmd.setTextureDataCube.dataLength
					);
					break;
				case GETTEXTUREDATA2D:
					device.GetTextureData2D(
						cmd.getTextureData2D.texture,
						cmd.getTextureData2D.format,
						cmd.getTextureData2D.width,
						cmd.getTextureData2D.height,
						cmd.getTextureData2D.level,
						cmd.getTextureData2D.subX,
						cmd.getTextureData2D.subY,
						cmd.getTextureData2D.subW,
						cmd.getTextureData2D.subH,
						cmd.getTextureData2D.data,
						cmd.getTextureData2D.startIndex,
						cmd.getTextureData2D.elementCount,
						cmd.getTextureData2D.elementSizeInBytes
					);
					break;
				case GETTEXTUREDATA3D:
					device.GetTextureData3D(
						cmd.getTextureData3D.texture,
						cmd.getTextureData3D.format,
						cmd.getTextureData3D.left,
						cmd.getTextureData3D.top,
						cmd.getTextureData3D.front,
						cmd.getTextureData3D.right,
						cmd.getTextureData3D.bottom,
						cmd.getTextureData3D.back,
						cmd.getTextureData3D.level,
						cmd.getTextureData3D.data,
						cmd.getTextureData3D.startIndex,
						cmd.getTextureData3D.elementCount,
						cmd.getTextureData3D.elementSizeInBytes
					);
					break;
				case GETTEXTUREDATACUBE:
					device.GetTextureDataCube(
						cmd.getTextureDataCube.texture,
						cmd.getTextureDataCube.format,
						cmd.getTextureDataCube.size,
						cmd.getTextureDataCube.cubeMapFace,
						cmd.getTextureDataCube.level,
						cmd.getTextureDataCube.subX,
						cmd.getTextureDataCube.subY,
						cmd.getTextureDataCube.subW,
						cmd.getTextureDataCube.subH,
						cmd.getTextureDataCube.data,
						cmd.getTextureDataCube.startIndex,
						cmd.getTextureDataCube.elementCount,
						cmd.getTextureDataCube.elementSizeInBytes
					);
					break;
				case GENCOLORRENDERBUFFER:
					cmd.genColorRenderbuffer.retval = device.GenRenderbuffer(
						cmd.genColorRenderbuffer.width,
						cmd.genColorRenderbuffer.height,
						cmd.genColorRenderbuffer.format,
						cmd.genColorRenderbuffer.multiSampleCount,
						cmd.genColorRenderbuffer.texture
					);
					break;
				case GENDEPTHRENDERBUFFER:
					cmd.genDepthRenderbuffer.retval = device.GenRenderbuffer(
						cmd.genDepthRenderbuffer.width,
						cmd.genDepthRenderbuffer.height,
						cmd.genDepthRenderbuffer.format,
						cmd.genDepthRenderbuffer.multiSampleCount
					);
					break;
				default:
					throw new InvalidOperationException(cmd.type.ToString());
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CreateEffectCMD
	{
		public int type;

		public byte[] effectCode;

		public IGLEffect retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CloneEffectCMD
	{
		public int type;

		public IGLEffect cloneSource;

		public IGLEffect retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GenVertexBufferCMD
	{
		public int type;

		public bool dynamic;
		public BufferUsage usage;
		public int vertexCount;
		public int vertexStride;

		public IGLBuffer retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GenIndexBufferCMD
	{
		public int type;

		public bool dynamic;
		public BufferUsage usage;
		public int indexCount;
		public IndexElementSize indexElementSize;

		public IGLBuffer retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SetVertexBufferDataCMD
	{
		public int type;

		public IGLBuffer buffer;
		public int offsetInBytes;
		public IntPtr data;
		public int dataLength;
		public SetDataOptions options;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SetIndexBufferDataCMD
	{
		public int type;

		public IGLBuffer buffer;
		public int offsetInBytes;
		public IntPtr data;
		public int dataLength;
		public SetDataOptions options;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GetVertexBufferDataCMD
	{
		public int type;

		public IGLBuffer buffer;
		public int offsetInBytes;
		public IntPtr data;
		public int startIndex;
		public int elementCount;
		public int elementSizeInBytes;
		public int vertexStride;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GetIndexBufferDataCMD
	{
		public int type;

		public IGLBuffer buffer;
		public int offsetInBytes;
		public IntPtr data;
		public int startIndex;
		public int elementCount;
		public int elementSizeInBytes;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CreateTexture2DCMD
	{
		public int type;

		public SurfaceFormat format;
		public int width;
		public int height;
		public int levelCount;
		public bool isRenderTarget;

		public IGLTexture retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CreateTexture3DCMD
	{
		public int type;

		public SurfaceFormat format;
		public int width;
		public int height;
		public int depth;
		public int levelCount;

		public IGLTexture retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct CreateTextureCubeCMD
	{
		public int type;

		public SurfaceFormat format;
		public int size;
		public int levelCount;
		public bool isRenderTarget;

		public IGLTexture retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SetTextureData2DCMD
	{
		public int type;

		public IGLTexture texture;
		public SurfaceFormat format;
		public int x;
		public int y;
		public int w;
		public int h;
		public int level;
		public IntPtr data;
		public int dataLength;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SetTextureData3DCMD
	{
		public int type;

		public IGLTexture texture;
		public SurfaceFormat format;
		public int level;
		public int left;
		public int top;
		public int right;
		public int bottom;
		public int front;
		public int back;
		public IntPtr data;
		public int dataLength;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct SetTextureDataCubeCMD
	{
		public int type;

		public IGLTexture texture;
		public SurfaceFormat format;
		public int xOffset;
		public int yOffset;
		public int width;
		public int height;
		public CubeMapFace cubeMapFace;
		public int level;
		public IntPtr data;
		public int dataLength;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GetTextureData2DCMD
	{
		public int type;

		public IGLTexture texture;
		public SurfaceFormat format;
		public int width;
		public int height;
		public int level;
		public int subX;
		public int subY;
		public int subW;
		public int subH;
		public IntPtr data;
		public int startIndex;
		public int elementCount;
		public int elementSizeInBytes;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GetTextureData3DCMD
	{
		public int type;

		public IGLTexture texture;
		public SurfaceFormat format;
		public int left;
		public int top;
		public int front;
		public int right;
		public int bottom;
		public int back;
		public int level;
		public IntPtr data;
		public int startIndex;
		public int elementCount;
		public int elementSizeInBytes;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GetTextureDataCubeCMD
	{
		public int type;

		public IGLTexture texture;
		public SurfaceFormat format;
		public int size;
		public CubeMapFace cubeMapFace;
		public int level;
		public int subX;
		public int subY;
		public int subW;
		public int subH;
		public IntPtr data;
		public int startIndex;
		public int elementCount;
		public int elementSizeInBytes;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GenColorRenderbufferCMD
	{
		public int type;

		public int width;
		public int height;
		public SurfaceFormat format;
		public int multiSampleCount;
		public IGLTexture texture;

		public IGLRenderbuffer retval;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GenDepthRenderbufferCMD
	{
		public int type;

		public int width;
		public int height;
		public DepthFormat format;
		public int multiSampleCount;

		public IGLRenderbuffer retval;
	}
}
