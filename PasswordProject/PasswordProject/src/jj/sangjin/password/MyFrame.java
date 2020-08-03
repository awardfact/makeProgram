package jj.sangjin.password;

import javax.swing.JFrame;

public class MyFrame extends JFrame{
	
	private static int width = 600;   // ����ũ��
	private static int height = 500; // ����ũ��
	MakePanel makePanel;
	MainPanel mainPanel;
	OutputPanel outputPanel;
	PasswordInputPanel passwordInputPanel;
	Thread t;

	public MyFrame() {
		
		
		makePanel = new MakePanel();          // �н����� ����� �޴� �г� ��ä ����
		mainPanel = new MainPanel();          //  �����г� ��ü ����
		outputPanel = new OutputPanel();       //  �н����� �ҷ����� �޴� �г� ��ü ����
		passwordInputPanel = new PasswordInputPanel(); // �н����� �Է��ϱ� �޴� �г� ����
		/*this.setUndecorated(true);*/	
		this.setSize(width,height);  // ���α׷� ũ��
		this.setTitle("�н����� ������");   // ���α׷� �̸�
		this.setVisible(true);	
		this.add(mainPanel);   // �����гθ��� ���̰� ��
		
		
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
		if(mainPanel.menu1 == 1) {	  // �����гο��� �н����� ����� ��ư�� Ŭ���ϸ� �Ͼ�� �̺�Ʈ 
			this.getContentPane().remove(mainPanel);  // �����г��� ������ �ʰ� �ϰ�
			this.getContentPane().add(makePanel);   // �н����� ����� �г��� ���̰� ��
			mainPanel.threadStop(t);
			this.validate();
			repaint(); // �ٽ�ĥ�ϱ�
			mainPanel.menu1 = 0;  // ȭ�� ��ȯ�ϰ� menu1���ڸ� �ٽ� 0���� �ǵ���

		}
		if(makePanel.makeback == 1) {  //�ٽ� �����гη� ���ƿ��� ���� �ڵ�   makePanle���� �ڷΰ��ⰰ���� ������ makeback�� 1�̵Ǹ� ����ȭ������
			this.getContentPane().remove(makePanel);  // makePanle�� �Ⱥ��̰� �ϰ�
			this.getContentPane().add(mainPanel);  // �����г��� ���̰� ��
			mainPanel.count = 11;
			t = mainPanel.threadMake();
			t.start();
			this.validate(); 
			repaint();
			makePanel.makeback = 0;//ȭ�� ��ȯ�ϰ� ���ڸ� �ٽ� 0���� �ǵ���

		}
		if(mainPanel.menu2 == 1) {	 // �����гο��� �н����� �Է��ϱ� ��ư�� Ŭ���ϸ� �Ͼ�� �̺�Ʈ 
			this.getContentPane().remove(mainPanel);  // mainPanel�� �����ϰ�
			this.getContentPane().add(passwordInputPanel);  // passwordInputPanel�� add�Ͽ� passwordInputPanel�� ���̰� ��
			mainPanel.threadStop(t);
			this.validate();
			repaint();
			mainPanel.menu2 = 0;

		}
		if(passwordInputPanel.inputBack == 1) {  //passwordInputPanel���� �����гη� ���ư��� �ڵ�
			this.getContentPane().remove(passwordInputPanel);
			this.getContentPane().add(mainPanel);
			mainPanel.count = 11;
			t = mainPanel.threadMake();
			t.start();
			this.validate();
			repaint();
			passwordInputPanel.inputBack = 0;

		}
		if(mainPanel.menu3 == 1) {	// ���θ޴����� �н����� �ҷ����� ��ư�� ������ outputPanel�� ȭ�鿡 ���̰� ��
			this.getContentPane().remove(mainPanel);
			this.getContentPane().add(outputPanel);
			mainPanel.threadStop(t);
			this.validate();
			repaint();
			mainPanel.menu3 = 0;

		}
		if(outputPanel.outputBack == 1) {  // outputPanel���� ���θ޴��� ���ư���
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
