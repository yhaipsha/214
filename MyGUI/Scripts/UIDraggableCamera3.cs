//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2012 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Works together with UIDragCamera script, allowing you to drag a secondary camera while keeping it constrained to a certain area.
/// </summary>

[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Game/Draggable Camera")]
public class UIDraggableCamera3 : IgnoreTimeScale
{
	/// <summary>
	/// Root object that will be used for drag-limiting bounds.
	/// </summary>
	public Transform rootForBounds;

	/// <summary>
	/// Scale value applied to the drag delta. Set X or Y to 0 to disallow dragging in that direction.
	/// </summary>
	public Vector2 scale = Vector2.one;

	/// <summary>
	/// Effect the scroll wheel will have on the momentum.
	/// </summary>
	public float scrollWheelFactor = 0f;

	/// <summary>
	/// Effect to apply when dragging.
	/// </summary>
	public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;

	/// <summary>
	/// How much momentum gets applied when the press is released after dragging.
	/// </summary>
	public float momentumAmount = 35f;
	Camera mCam;
	
	///****************************************************************
	/// <summary>
	/// Horizontal scrollbar used for visualization.
	/// </summary>

	public UIScrollBar horizontalScrollBar;

	/// <summary>
	/// Vertical scrollbar used for visualization.
	/// </summary>
	public UIScrollBar verticalScrollBar;	
	public enum ShowCondition
	{
		Always,
		OnlyIfNeeded,
		WhenDragging,
	}
	public ShowCondition showScrollBars = ShowCondition.OnlyIfNeeded;
	
	//Bounds mBounds;
	bool mCalculatedBounds = false;
	bool mShouldMove = false;
	bool mIgnoreCallbacks = false;
	
	///****************************************************************
	
	
	
	
	Transform mTrans;
	bool mPressed = false;
	Vector2 mMomentum = Vector2.zero;
	Bounds mBounds;
	float mScroll = 0f;
	UIRoot mRoot;

	/// <summary>
	/// Current momentum, exposed just in case it's needed.
	/// </summary>
	public Vector2 currentMomentum { get { return mMomentum; } set { mMomentum = value; } }

	/// <summary>
	/// Cache the common components.
	/// </summary>
	void Awake ()
	{
//		mTrans = transform;
//		mPanel = GetComponent<UIPanel>();
		//拖拽相机，不是面板

		
		mCam = camera;
		mTrans = transform;

		if (rootForBounds == null)
		{
			Debug.LogError(NGUITools.GetHierarchy(gameObject) + " needs the 'Root For Bounds' parameter to be set", this);
			enabled = false;
		}
	}
	
	public bool shouldMoveVertically
	{
		get
		{
			return true;
//			float size = bounds.size.y;
//			if (mPanel.clipping == UIDrawCall.Clipping.SoftClip) size += mPanel.clipSoftness.y * 2f;
//			return size > mPanel.clipRange.w;
		}
	}
	
	public bool shouldMoveHorizontally
	{
		get
		{
			return true;
//			float size = bounds.size.x;
//			if (mPanel.clipping == UIDrawCall.Clipping.SoftClip) size += mPanel.clipSoftness.x * 2f;
//			return size > mPanel.clipRange.z;
		}
	}
	/// <summary>
	/// Cache the root.
	/// </summary>

	void Start () {
	
		mRoot = NGUITools.FindInParents<UIRoot>(gameObject);

		/*
		UpdateScrollbars(true);

		if (horizontalScrollBar != null)
		{
			horizontalScrollBar.onChange += OnHorizontalBar;
			horizontalScrollBar.alpha = ((showScrollBars == ShowCondition.Always) || shouldMoveHorizontally) ? 1f : 0f;
		}

		if (verticalScrollBar != null)
		{
			verticalScrollBar.onChange += OnVerticalBar;
			verticalScrollBar.alpha = ((showScrollBars == ShowCondition.Always) || shouldMoveVertically) ? 1f : 0f;
		}
	
		*/
	 
	 
	  }
	
	///****************************************************************
	public void DisableSpring ()
	{
		SpringPanel sp = GetComponent<SpringPanel>();
		if (sp != null) sp.enabled = false;
	}
	public void SetDragAmount (float x, float y, bool updateScrollbars)
	{
		DisableSpring();
		/*
		Bounds b = bounds;
		if (b.min.x == b.max.x || b.min.y == b.max.x) return;
		Vector4 cr = mPanel.clipRange;

		float hx = cr.z * 0.5f;
		float hy = cr.w * 0.5f;
		float left = b.min.x + hx;
		float right = b.max.x - hx;
		float bottom = b.min.y + hy;
		float top = b.max.y - hy;

		if (mPanel.clipping == UIDrawCall.Clipping.SoftClip)
		{
			left -= mPanel.clipSoftness.x;
			right += mPanel.clipSoftness.x;
			bottom -= mPanel.clipSoftness.y;
			top += mPanel.clipSoftness.y;
		}

		// Calculate the offset based on the scroll value
		float ox = Mathf.Lerp(left, right, x);
		float oy = Mathf.Lerp(top, bottom, y);

		// Update the position
		if (!updateScrollbars)
		{
			Vector3 pos = mTrans.localPosition;
			if (scale.x != 0f) pos.x += cr.x - ox;
			if (scale.y != 0f) pos.y += cr.y - oy;
			mTrans.localPosition = pos;
		}

		// Update the clipping offset
		cr.x = ox;
		cr.y = oy;
		mPanel.clipRange = cr;
		*/
		// Update the scrollbars, reflecting this change
		if (updateScrollbars) UpdateScrollbars(false);
	}

	/// <summary>
	/// Triggered by the horizontal scroll bar when it changes.
	/// </summary>

	void OnHorizontalBar (UIScrollBar sb)
	{
		if (!mIgnoreCallbacks)
		{
			float x = (horizontalScrollBar != null) ? horizontalScrollBar.scrollValue : 0f;
			float y = (verticalScrollBar != null) ? verticalScrollBar.scrollValue : 0f;
			SetDragAmount(x, y, false);
		}
	}

	/// <summary>
	/// Triggered by the vertical scroll bar when it changes.
	/// </summary>

	void OnVerticalBar (UIScrollBar sb)
	{
		if (!mIgnoreCallbacks)
		{
			float x = (horizontalScrollBar != null) ? horizontalScrollBar.scrollValue : 0f;
			float y = (verticalScrollBar != null) ? verticalScrollBar.scrollValue : 0f;
			SetDragAmount(x, y, false);
		}
	}
	
	/*public Bounds bounds
	{
		get
		{
			if (!mCalculatedBounds)
			{
				mCalculatedBounds = true;
				mBounds = NGUIMath.CalculateRelativeWidgetBounds(mTrans, mTrans);
			}
			return mBounds;
		}
	}*/
	
	bool shouldMove
	{
		get
		{
			/*
			if (!disableDragIfFits) return true;

			if (mPanel == null) mPanel = GetComponent<UIPanel>();
			Vector4 clip = mPanel.clipRange;
			Bounds b = bounds;

			float hx = (clip.z == 0f) ? Screen.width  : clip.z * 0.5f;
			float hy = (clip.w == 0f) ? Screen.height : clip.w * 0.5f;

			if (!Mathf.Approximately(scale.x, 0f))
			{
				if (b.min.x < clip.x - hx) return true;
				if (b.max.x > clip.x + hx) return true;
			}

			if (!Mathf.Approximately(scale.y, 0f))
			{
				if (b.min.y < clip.y - hy) return true;
				if (b.max.y > clip.y + hy) return true;
			}*/
			return false;
		}
	}
	/// <summary>
	/// Update the values of the associated scroll bars.
	/// </summary>

	public void UpdateScrollbars (bool recalculateBounds)
	{
		//if (mPanel == null) return;

		if (horizontalScrollBar != null || verticalScrollBar != null)
		{
			if (recalculateBounds)
			{
				mCalculatedBounds = false;
				mShouldMove = shouldMove;
			}

			/*Bounds b = bounds;
			Vector2 bmin = b.min;
			Vector2 bmax = b.max;
			
			if (mPanel.clipping == UIDrawCall.Clipping.SoftClip)
			{
				Vector2 soft = mPanel.clipSoftness;
				bmin -= soft;
				bmax += soft;
			}

			if (horizontalScrollBar != null && bmax.x > bmin.x)
			{
				Vector4 clip = mPanel.clipRange;
				float extents = clip.z * 0.5f;
				float min = clip.x - extents - b.min.x;
				float max = b.max.x - extents - clip.x;

				float width = bmax.x - bmin.x;
				min = Mathf.Clamp01(min / width);
				max = Mathf.Clamp01(max / width);

				float sum = min + max;
				mIgnoreCallbacks = true;
				horizontalScrollBar.barSize = 1f - sum;
				horizontalScrollBar.scrollValue = (sum > 0.001f) ? min / sum : 0f;
				mIgnoreCallbacks = false;
			}

			if (verticalScrollBar != null && bmax.y > bmin.y)
			{
				Vector4 clip ;//= mPanel.clipRange;
				float extents = clip.w * 0.5f;
				float min = clip.y - extents - bmin.y;
				float max = bmax.y - extents - clip.y;

				float height = bmax.y - bmin.y;
				min = Mathf.Clamp01(min / height);
				max = Mathf.Clamp01(max / height);
				float sum = min + max;

				mIgnoreCallbacks = true;
				verticalScrollBar.barSize = 1f - sum;
				verticalScrollBar.scrollValue = (sum > 0.001f) ? 1f - min / sum : 0f;
				mIgnoreCallbacks = false;
			}*/
		}
		else if (recalculateBounds)
		{
			mCalculatedBounds = false;
		}
	}
	
	///****************************************************************
	
	
	/// <summary>
	/// 计算偏移量被限制在面板的边界。
	/// Calculate the offset needed to be constrained within the panel's bounds.
	/// </summary>

	Vector3 CalculateConstrainOffset ()
	{
		if (rootForBounds == null || rootForBounds.childCount == 0) return Vector3.zero;

		Vector3 bottomLeft = new Vector3(mCam.rect.xMin * Screen.width, mCam.rect.yMin * Screen.height, 0f);
		Vector3 topRight   = new Vector3(mCam.rect.xMax * Screen.width, mCam.rect.yMax * Screen.height, 0f);

		bottomLeft = mCam.ScreenToWorldPoint(bottomLeft);
		topRight = mCam.ScreenToWorldPoint(topRight);

		Vector2 minRect = new Vector2(mBounds.min.x, mBounds.min.y);
		Vector2 maxRect = new Vector2(mBounds.max.x, mBounds.max.y);

		return NGUIMath.ConstrainRect(minRect, maxRect, bottomLeft, topRight);
	}

	/// <summary>
	/// Constrain the current camera's position to be within the viewable area's bounds.
	/// </summary>

	public bool ConstrainToBounds (bool immediate)
	{
		if (mTrans != null && rootForBounds != null)
		{
			Vector3 offset = CalculateConstrainOffset();

			if (offset.magnitude > 0f)
			{
				if (immediate)
				{
					mTrans.position -= offset;
				}
				else
				{
					SpringPosition sp = SpringPosition.Begin(gameObject, mTrans.position - offset, 13f);
					sp.ignoreTimeScale = true;
					sp.worldSpace = true;
				}
				return true;
			}
		}
		return false;
	}
	
	/// <summary>
	/// Calculate the bounds of all widgets under this game object.
	/// </summary>

	public void Press (bool isPressed)
	{
		if (rootForBounds != null)
		{
			mPressed = isPressed;

			if (isPressed)
			{
				// Update the bounds
				mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(rootForBounds);

				// Remove all momentum on press
				mMomentum = Vector2.zero;
				mScroll = 0f;

				// Disable the spring movement
				SpringPosition sp = GetComponent<SpringPosition>();
				if (sp != null) sp.enabled = false;
			}
			else if (dragEffect == UIDragObject.DragEffect.MomentumAndSpring)
			{
				ConstrainToBounds(false);
			}
		}
	}

	/// <summary>
	/// Drag event receiver.
	/// </summary>

	public void Drag (Vector2 delta)
	{
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
		if (mRoot != null) delta *= mRoot.pixelSizeAdjustment;

		Vector2 offset = Vector2.Scale(delta, -scale);
		mTrans.localPosition += (Vector3)offset;

		// Adjust the momentum
		mMomentum = Vector2.Lerp(mMomentum, mMomentum + offset * (0.01f * momentumAmount), 0.67f);

		// Constrain the UI to the bounds, and if done so, eliminate the momentum
		if (dragEffect != UIDragObject.DragEffect.MomentumAndSpring && ConstrainToBounds(true))
		{
			mMomentum = Vector2.zero;
			mScroll = 0f;
		}
	}

	/// <summary>
	/// If the object should support the scroll wheel, do it.
	/// </summary>

	public void Scroll (float delta)
	{		
		if (enabled && NGUITools.GetActive(gameObject))
		{
			if (Mathf.Sign(mScroll) != Mathf.Sign(delta)) mScroll = 0f;
			mScroll += delta * scrollWheelFactor;
		}
	}

	/// <summary>
	/// Apply the dragging momentum.
	/// </summary>

	void Update ()
	{
		float delta = UpdateRealTimeDelta();

		if (mPressed)
		{
			// Disable the spring movement
			SpringPosition sp = GetComponent<SpringPosition>();
			if (sp != null) sp.enabled = false;
			mScroll = 0f;
		}
		else
		{
			mMomentum += scale * (mScroll * 20f);
			mScroll = NGUIMath.SpringLerp(mScroll, 0f, 20f, delta);

			if (mMomentum.magnitude > 0.01f)
			{
				// Apply the momentum
				mTrans.localPosition += (Vector3)NGUIMath.SpringDampen(ref mMomentum, 9f, delta);
				mBounds = NGUIMath.CalculateAbsoluteWidgetBounds(rootForBounds);

				if (!ConstrainToBounds(dragEffect == UIDragObject.DragEffect.None))
				{
					SpringPosition sp = GetComponent<SpringPosition>();
					if (sp != null) sp.enabled = false;
				}
				return;
			}
			else mScroll = 0f;
		}

		// Dampen the momentum
		NGUIMath.SpringDampen(ref mMomentum, 9f, delta);
	}
}