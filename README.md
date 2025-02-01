C4 Seri của anh SAI. Đây sẽ là móc thời gian mình làm về về project của anh SAI và một số tính năng mình tự thêm vào để tiện phát triển về sau!
- 16/1/2025: E9 - E20
  + Tạo github làm quen với môi trường 3D, mới nên hơi ngợp nhưng vẫn đã hoàn thành.
  + Hoàn thành các bước xây dựng map (NavMeshSurface), hệ thống di chuyển AI (NavAgent cơ bản)
    
- 17/1/2025: E21 - E29
  + Thêm mới nhân vật và animation di chuyển (Mixamo.com), thành công thiết lập hệ thống Generic Singleton (Tập 27), xây dựng thành công hệ thống di chuyển theo Path (PathManager Singleton).
  + Trong script của anh SAI ở tập 26 về phần hàm GetPath anh SAI đã dùng overloading "string" và "index" để tìm Path, tuy nhiên mình muốn sau này có thể phát triển nhiều đường đi khác nhau, nên tự thêm vào một enum để GetPath (*)
  
- 18/1/2025: E30 - E42
  + Hoàn thành các cơ bản về Tower(Thêm mục tiêu gần vào danh sách, tìm mục tiêu gần nhất).
  + Hoàn thành về Spawner Generic cơ bản, Despawn.
  + Hoàn thành được Shooting của Tower.
    
* Chú Ý: Trong các tập từ tập 29 - 40 anh Sai có đề cập đến việc cập nhật danh sách Enemy và Lookat Enemy liên tục trong FixedUpdate là không cần thiết nên đã dùng đến Invoke để gọi đệ quy tại thời điểm Start.
    - Liệu có thể dùng courotine để thay thế ?
    - Liệu Tower khi trở về pool lại được spawn ra thì Invoke có hoạt động tốt. Vì Start chỉ gọi 1 lần duy nhất !

- 19/1/2025: E43 - E51
  + Hoàn thành cơ chết truyền nhận Damage của Enemy và Bullet.
  + Hoàn thành cách xử lí Animation quái vật khi chết, khi bị đạn tấn công, và khi hồi sinh sẽ thiết lập lại các chỉ số cần thiết.
  + Hoàn thành được cơ chế các viên đạn, Enemy... bị hủy sẽ được đưa về Holder

  * Vì đã học C3 khá nhiều lần nên tiến độ C4 khá nhanh, đã hoàn thành được 50% của dự án trong 4 ngày ^^

- 20/1/2025: E52 - E59
  + Sử dụng thành công Raycast để Tower không Lookat vào các Enemy đang bị che bởi vách tường.
  + Áp dụng thành công Model ThirdPerSon vào scene và điều khiển các animation.
  + Học được cách sử dụng Animation Rigging của Unity để điều khiển các animation của bộ phận cơ thể
 
 * Hơn đã được hơn 50% chặn đường mặc dù chưa gặp khó khăn về phần code nhưng về Animation thì cần trao dồi thêm ^^

* 21/1/2025: Hôm nay mình không làm thêm tính năng mới tuy nhiên mình quyết định xem lại tất cả code đã làm và note một số code cần thay đổi lại tại đây 
  + TowerTargeting: ở đây kiểm tra Enemy tuy nhiên để gọi FixedUpdate thì có lẻ không cần thiết nên đổi sang Coroutine.
  + Despawn, Spawner cũng tương tự nếu giả sử có rất nhiều Obj nếu trên 1k Obj thì nên đổi sang Coroutine.
  + Moving với trường hợp của Bullet FLying, Enemy Moving cũng tương tự thế nên đổi sang Coroutine.
  + Với việc dùng Bullet, Enemy, Path... bằng GetName sẽ khá khó quản lí vì thế nên đổi sang Enum để chọn.
 
  * Hiện tại mình đã làm đến tập 59 của Seri mình muốn note lại 1 số cần thay đổi sau khi kết thúc seri này. Vì thế mình sẽ chậm tiến độ lại một tí để đảm bảo game làm ra sẽ hoàn thiện, hiệu suất tốt.
 
* 22 - 23/1/2025 : E60 - E62
  + Import thành công Model ThirdPerSon và đã thành công tạo hiệu ứng Attack
  + Ở tập 59 - 60 các bạn phải xem thật kĩ để tránh lỗi animation, kèm theo đó ở phần Rigging của Spine mình đã test và đúng nhất là mixamorig:Spine2 chứ không phải Spine.
  + Mình đã test thử các coroutine mà mình đã nêu ra tuy hiệu xuất tăng được một tí nhưng về mặt Animation và độ mượt mà trong di chuyển bị chậm đi.

  * Mình nghĩ nên dùng các loại Update, FixedUpdate như a Sai Game đã làm. Vì hiện tại con game chưa quá nặng đến mức phải tối ưu như vậy.
   
* 24/1/2025 : E63 - E66 
  + Thành công tạo ra hệ thống Shooting và Effect cơ bản.
  + Thiết lập được hệ thông inventory (Currencies , Itmes)
  + Làm quen với Scriptable Object.
    
* Trên thực tế các hệ thống này mình đã học ở C3 và áp dụng thành công vào Game 2D đầu tay của mình nên không gặp quá nhiều khó khăn.
Chú Ý: Ở E63 - E64 anh Sai có tí chỉnh sử ở hàm Update ở class AttackAbstract thay vì dùng Update sẽ gây ra lỗi spawn ra đạn ở 2 vị trí. Mình đã lên hỏi GPT và sửa lại LateUpdate thì bug đó đã được fix. Đây là lý do.
  + Vì ở Rig mình dùng Aiming ở dạng Update và AttackPoint cũng từ đó mà thay đổi nên khi nhận tính hiệu đầu vào liên tục thì AttackPoint sẽ cập nhật vị trí liên tục mỗi Frame.
  + Việc Spawn mỗi Frame như thế sẽ có tức khắc vị trí của AttackPoint bị trở về vị trí cũ nên bị xảy ra việc Spawn viên đạn sai vị trí.
  + Gọi LateUpdate từ là sau khi Input vào thì lập tức gọi Spawn liền nên tọa độ của AttackPoint sẽ được cập nhạt đúng với vị trí mình đã Input.

Đó là theo như mình tìm hiểu và mình đã hoàn thành đến tập 66 của Seri trong vòng 1 tuần. Vì có kiến thức của C3 nên đi khá nhanh.^^

* 25/1/2025 : E67 - E73
  + Thành công tạo hệ thống inventory khi giết quái nhận được vàng 
  + Thiết kê thành công UI cơ bản của Inventory.
  + Cập nhật số lượng và tên Items và Currencies lên UI
* Chú ý: Ở list Item khi anh em dùng Foreach để Add hoặc Remove một Item thì hãy cẩn thận vì nó thay đổi số lượng của list Item sẽ gây lỗi nếu không triển khai tốt. Nên dùng For và RemoveAt nếu anh em không rõ về Foreach.
  
Các hệ thông này đã được anh Sai hướng dẫn trong C3 nên việc làm lại với mình cũng không quá khó khăn. Còn 2 ngày nữa mình sẽ nghỉ tết nên mình sẽ cố gắng Done luôn seri này trong 2 ngày nữa ^^

* 26/1/2025 : E74 - E80
  + Tạo được hệ thống Add Item, Remove Item trong Inventory và hiển thị ra UI.
  + Tạo hệ thống ItemDropManager để drop ra các vật phẩm khi tiêu diệt quái.
  + Tạo hệ thống InputHotkey để bật tắt Inventory... bằng phím tắt

* Chú ý: Anh em nên chú ý ở tập Inventory kĩ một tí vì phải gọi đúng hàm và Enum của chúng phải tương thích với mục đích đặt ra nếu không sẽ xảy ra lỗi khó hiêu ^^

* 27/1/2025 : E81 - E85
  + Tạo hệ thống level cho các đối tượng như Player, Tower....
  + Tạo UI hiển thị Exp, Level cho Player, Tower....
  + Hiển thị thanh máu cho Enemy.
  + Tạo hiệu ứng cho Tower khi shooting.


* Chú ý: Với các code anh Sai bắt buộc tạo ra thì anh em không nên bỏ qua, hãy tạo theo thay vì chỉ thêm hàm vào class khác
  + Ở KillCount thì mình triển khai theo dạng set Shooter để có thể biết được chính xác khâu súng nào giết quái (C3)
  + Các class như Text, Slider để hiển thị, vì dùng khác nhiều nơi và tiện dùng cho sau này mình đã áp dụng Generic Class vào abstract để tiện gọi các Controllder.


* Kế hoạch sau khi kết thúc hành trình C4: Mình sẽ làm theo các bước của a Sai từ C4 từ những tập 20 ~ tập 95 để có thể làm 1 game hoàn chỉnh 
  + Tập 20 ~ tập 30: Thiết kế thêm map, path( Dự kiến 4 map ) các animation cho các enemy khác nhau( dự kiến 7 ~ 10 Enemy ).
  + Tập 31 ~ tập 40: Tối ưu lại các code gây tốn tài nguyên game không cần thiết mà A Sai đã đề cập trong clip.
  + Tập 41 ~ tập 50: Tìm và thiết kế lại các class có khả năng dùng Genergic để code có thể tối ưu nhất có thể.
  + Tập 51 ~ tập 60: Thiết kế thêm 2 - 3 nhân vật khác nhau với các vai trò khác nhau trong game(dự định sẽ là game MultiPlay).
  + Tập 61 ~ tập 70: Thêm các weapons, items cần thiết để có thể có nhiều lối chơi đa dạng.
  + Tập 71 ~ tập 80: Cập nhật thêm phím tắt, hiển thị UI một cách tối ưu dễ hiểu nhất có thể(cơ chế Inventory chung).
  + Tập 80 ~ tập 90: Tìm kiếm và thêm các hiệu ứng cho skill, hoạt ảnh cho các cơ chế như xây trụ, trụ hết khả năng bắn ...
  + Tập 91 ~ tập 95: Nâng cấp âm thanh, hiệu ứng của game play.

* Các kế hoạch này mình đề ra dự định sẽ hoàn thành trong 1 tháng. Hiện tại mình chỉ dám đặt ra các kế hoạch như Seri của a Sai dã vẽ ra sẵn vì khả năng, thời gian có giới hạn. Nên mình sẽ hoàn thành hết tất cả kế hoạch đề ra rồi mới đến kế hoạch khác. Mong anh em có thể theo dõi và giúp đỡ mình ^^

* 31/1/2025 : E86 - E95
  + Tạo được hệ thông hiệu ứng cho các hành động như Enemy being hit, Tower Muzzle... (Còn hạn chế và package nên chỉ tạo ít hiệu ứng)
  + Tạo được hệ thống quản lí âm thanh và áp dụng thành công vào Tower, Enemy, Backgroun Music.
 

* Mục tiêu 1: Tập 20 ~ tập 30: Thiết kế thêm map, path( Dự kiến 4 map ) các animation cho các enemy khác nhau( dự kiến 7 ~ 10 Enemy )
  + Đã thiết kê thành công 4 Map :
    + 2 Map gồm 1 Path để Enemy di chuyển (Độ khó - Dễ)
    + 1 Map gồm 2 Path để Enemy di chuyển (Độ khó - Trung)
    + 1 Map gồm 2 Path để Enemy di chuyển (Độ khó - Khó, Map MultiPlay)
  + Thiết kế thành công 8 Enemy với 2 loại khác nhau gồm Grutes, Zombies:
    + Grutes : Quái vật to, trâu khả năng hồi máu, tạo khiên... sẽ được phát triển trong tương lai
    + Zobies : Quái vật nhỏ, mảnh mai, khó bắn trúng, khả năng tăng tốc khi máu thấp, miễn nhiễm sát thương trong thời gian ngắn... sẽ được phát triển trong tương lai
  + Thiết kế SpawnPoint cho Enemy, Enemy dựa vào SpawnPoint để tìm ra Path di chuyển hợp lí. 
Mục tiêu đã hoàn thành về việc thiết lập các Enemy, Map và Spawn Point để hỗ trợ các Wave quái phát triển sau này.
Sau 12 ngày thì mình cùng đã hoàn thành được C4 của A Sai, đã hoàn thành tốt các cơ bản mà trong Seri của anh Sai đã hướng dẫn. Tiếp theo mình sẽ triển khai như kế hoạch đã đề ra ở trên. Để có thể triển khai 1 con game hoàn thiện nhất có thể ^^
