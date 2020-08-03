package jj.sangjin.password;

import javax.swing.JFrame;

public class MyFrame extends JFrame{
	
	private static int width = 600;   // 가로크기
	private static int height = 500; // 세로크기
	MakePanel makePanel;
	MainPanel mainPanel;
	OutputPanel outputPanel;
	PasswordInputPanel passwordInputPanel;
	Thread t;

	public MyFrame() {
		
		
		makePanel = new MakePanel();          // 패스워드 만들기 메뉴 패널 객채 생성
		mainPanel = new MainPanel();          //  메인패널 객체 생성
		outputPanel = new OutputPanel();       //  패스워드 불러오기 메뉴 패널 객체 생성
		passwordInputPanel = new PasswordInputPanel(); // 패스워드 입력하기 메뉴 패널 생성
		/*this.setUndecorated(true);*/	
		this.setSize(width,height);  // 프로그램 크기
		this.setTitle("패스워드 생성기");   // 프로그램 이름
		this.setVisible(true);	
		this.add(mainPanel);   // 메인패널먼저 보이게 함
		
		
		t = mainPanel.threadMake();
		t.start();
		
		
		while(true){

			frameContinue();
		try {
			Thread.sleep(500);
		}catch(Exception e) {}
		}
	}
	
	
	
	public void frameContinue(){
		if(mainPanel.menu1 == 1) {	  // 메인패널에서 패스워드 만들기 버튼을 클릭하면 일어나는 이벤트 
			this.getContentPane().remove(mainPanel);  // 메인패널을 보이지 않게 하고
			this.getContentPane().add(makePanel);   // 패스워드 만들기 패널을 보이게 함
			mainPanel.threadStop(t);
			this.validate();
			repaint(); // 다시칠하기
			mainPanel.menu1 = 0;  // 화면 전환하고 menu1숫자를 다시 0으로 되돌림

		}
		if(makePanel.makeback == 1) {  //다시 메인패널로 돌아오기 위한 코드   makePanle에서 뒤로가기같은거 눌러서 makeback이 1이되면 메인화면으로
			this.getContentPane().remove(makePanel);  // makePanle을 안보이게 하고
			this.getContentPane().add(mainPanel);  // 메인패널을 보이게 함
			mainPanel.count = 11;
			t = mainPanel.threadMake();
			t.start();
			this.validate(); 
			repaint();
			makePanel.makeback = 0;//화면 전환하고 숫자를 다시 0으로 되돌림

		}
		if(mainPanel.menu2 == 1) {	 // 메인패널에서 패스워드 입력하기 버튼을 클릭하면 일어나는 이벤트 
			this.getContentPane().remove(mainPanel);  // mainPanel을 제거하고
			this.getContentPane().add(passwordInputPanel);  // passwordInputPanel을 add하여 passwordInputPanel이 보이게 함
			mainPanel.threadStop(t);
			this.validate();
			repaint();
			mainPanel.menu2 = 0;

		}
		if(passwordInputPanel.inputBack == 1) {  //passwordInputPanel에서 메인패널로 돌아가는 코드
			this.getContentPane().remove(passwordInputPanel);
			this.getContentPane().add(mainPanel);
			mainPanel.count = 11;
			t = mainPanel.threadMake();
			t.start();
			this.validate();
			repaint();
			passwordInputPanel.inputBack = 0;

		}
		if(mainPanel.menu3 == 1) {	// 메인메뉴에서 패스워드 불러오기 버튼을 눌르면 outputPanel이 화면에 보이게 함
			this.getContentPane().remove(mainPanel);
			this.getContentPane().add(outputPanel);
			mainPanel.threadStop(t);
			this.validate();
			repaint();
			mainPanel.menu3 = 0;

		}
		if(outputPanel.outputBack == 1) {  // outputPanel에서 메인메뉴로 돌아가기
			this.getContentPane().remove(outputPanel);
			this.getContentPane().add(mainPanel);
			mainPanel.count = 11;
			t = mainPanel.threadMake();
			t.start();
			this.validate();
			repaint();
			outputPanel.outputBack = 0;
		}
	}
}
