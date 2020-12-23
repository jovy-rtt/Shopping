$(document).ready(function(){
	//添加
  $(".add").click(function(){
	//获取个数
	//alert("add");
	var c = parseInt($(this).siblings("span").text());
	//判断是否还可以再加
	if(c>=3)
		alert("限购哦，亲~");
	else
	{
		c++;
		$(this).siblings("span").text(c);
		var d = $(this).parents(".number").prev().text().substring(1);
		$(this).parents(".text-center").find(".Subtotal").text("￥" + (c * d).toFixed(2));
	}
	a()
  });
  
  //减少
  $(".sub").click(function(){
	//获取个数
	var c = parseInt($(this).siblings("span").text());
	//判断是否还可以再减
	if(c<=1)
		alert("真的不能再减了");
	else
	{
		c--;
		$(this).siblings("span").text(c);
		var d = $(this).parents(".number").prev().text().substring(1);
		$(this).parents(".text-center").find(".Subtotal").text("￥" + (c * d).toFixed(2));
	}
	a();
  });
  
  
  $("input[type='checkbox']").on("click",function(){
	  //选中状态
	  var state = $(this).is(":checked");
	  //全选
	  var checkallstate = $(this).hasClass("checkall");
	  
	  
	  //选中
	  if(state)
	  {
		  //全选
		  if(checkallstate)
		  {
			  //全选
			  $("input[type='checkbox']").each(function(){
				  this.checked=true;
			  });
			  //alert("nihao");
			  b();
			  a();
		  }
		  else
		  {
			  
			  $(this).checked = true;
			  //为了判断全选是否选上
                var c = $("input[type='checkbox']:checked").length;
                var d = $("input").length - 1;
                if (c == d) {
                    $("input[type='checkbox']").each(function () {
                        this.checked = true
                    })
                }
                b();
                a();
		  }
	  }
	  else
	  {
		  if (checkallstate) {
                $("input[type='checkbox']").each(function () {
                    this.checked = false
                });
                b();
                a();
            } else {
                $(this).checked = false;
                var c = $(".th input[type='checkbox']:checked").length;
                var d = $("input").length - 1;
                if (c < d) {
                    $(".checkall").attr("checked", false)
                }
                b();
                a();
            }
	  }
  });
  
  
  //改变总件数
  function a(){
	  //总和
	  var sum=0;
	  var num = $(".text-center input[type='checkbox']:checked").length;
	  
  }
  
  function b()
  {
	  
  }
  
  
  
  
});