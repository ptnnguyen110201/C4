C4 Seri của anh SAI. Đây sẽ là móc thời gian mình làm về về project của anh SAI và một số tính năng mình tự thêm vào để tiện phát triển về sau!
- 16/1/2025:
  + Tạo github làm quen với môi trường 3D, mới nên hơi ngợp nhưng vẫn đã hoàn thành.
  + Hoàn thành các bước xây dựng map (NavMeshSurface), hệ thống di chuyển AI (NavAgent cơ bản)
    
- 17/1/2025:
  + Thêm mới nhân vật và animation di chuyển (Mixamo.com), thành công thiết lập hệ thống Generic Singleton (Tập 27), xây dựng thành công hệ thống di chuyển theo Path (PathManager Singleton).
  + Trong script của anh SAI ở tập 26 về phần hàm GetPath anh SAI đã dùng overloading "string" và "index" để tìm Path, tuy nhiên mình muốn sau này có thể phát triển nhiều đường đi khác nhau, nên tự thêm vào một enum để GetPath (*)
  
- 18/1/2025:
   + Hoàn thành các cơ bản về Tower(Thêm mục tiêu gần vào danh sách, tìm mục tiêu gần nhất).
   + Hoàn thành về Spawner Generic cơ bản, Despawn.
   + Hoàn thành được Shooting của Tower.
   * Chú Ý: Trong các tập từ tập 29 - 40 anh Sai có đề cập đến việc cập nhật danh sách Enemy và Lookat Enemy liên tục trong FixedUpdate là không cần thiết nên đã dùng đến Invoke để gọi đệ quy tại thời điểm Start.
        - Liệu có thể dùng courotine để thay thế ??????????
        - Liệu Tower khi trở về pool lại được spawn ra thì Invoke có hoạt động tốt. Vì Start chỉ gọi 1 lần duy nhất (***)

- 19/1/2025:
  + Hoàn thành cơ chết truyền nhận Damage của Enemy và Bullet.
  + Hoàn thành cách xử lí Animation quái vật khi chết, khi bị đạn tấn công, và khi hồi sinh sẽ thiết lập lại các chỉ số cần thiết.
  + Hoàn thành được cơ chế các viên đạn, Enemy... bị hủy sẽ được đưa về Holder

  * Vì đã học C3 khá nhiều lần nên tiến độ C4 khá nhanh, đã hoàn thành được 50% của dự án trong 4 ngày ^^
