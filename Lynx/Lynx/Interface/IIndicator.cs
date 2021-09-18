using Eto.Drawing;
using Eto.Forms;
using System;

namespace Lynx.Interface {
    /// <summary>
    /// 알림 바 인디케이터
    /// </summary>
    public interface IIndicator {
        /// <summary>
        /// 이미지
        /// </summary>
        Image Image { get; set; }
        /// <summary>
        /// 타이틀
        /// </summary>
        string Title { get; set; }
        /// <summary>
        /// 메뉴
        /// </summary>
        ContextMenu Menu { get; set; }

        /// <summary>
        /// 이미지 설정
        /// </summary>
        Image SetImage(Image image);
        /// <summary>
        /// 이미지 가져오기
        /// </summary>
        Image GetImage();
        /// <summary>
        /// 타이틀 설정
        /// </summary>
        string SetTitle(string title);
        /// <summary>
        /// 타이틀 가져오기
        /// </summary>
        string GetTitle();
        /// <summary>
        /// 메뉴 설정
        /// </summary>
        ContextMenu SetMemu(ContextMenu menu);
        /// <summary>
        /// 메뉴 가져오기
        /// </summary>
        ContextMenu GetMenu();
        /// <summary>
        /// 보이게합니다.
        /// </summary>
        void Show();
        /// <summary>
        /// 숨깁니다.
        /// </summary>
        void Hide();

        /// <summary>
        /// 좌클릭 이벤트
        /// </summary>
        event EventHandler<EventArgs> Activated;
    }
}
