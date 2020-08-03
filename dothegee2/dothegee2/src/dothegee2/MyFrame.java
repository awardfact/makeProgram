package dothegee2;

import java.awt.Cursor;
import java.awt.Image;
import java.awt.Point;
import java.awt.Toolkit;

import javax.swing.JFrame;

public class MyFrame extends JFrame{

	MainPanel mp;
	GamePanel gp;
	SoloGamePanel SP;
	ap	AP;
	String IP;
	
	Thread mainThread;
	Toolkit tk = Toolkit.getDefaultToolkit();
	Image img = tk.getImage("hammer.png");
	Cursor myCursor = tk.createCustomCursor(img, new Point(10,10),"dynamite stick");
	public MyFrame(String IP) {
		this.IP = IP;
		
		mp = new MainPanel();
		gp = new GamePanel(IP);
		SP = new SoloGamePanel();
		
		this.setTitle("�δ���");
		this.setSize(960,600);
		this.setVisible(true);
		this.add(mp);
		this.setCursor(myCursor);
		mainThread = mp.threadMake();
		mainThread.start();
		
		while(true) {
			if(mp.start == 1) {	  // �����гο��� �н����� ����� ��ư�� Ŭ���ϸ� �Ͼ�� �̺�Ʈ 
				this.getContentPane().remove(mp);  // �����г��� ������ �ʰ� �ϰ�
				this.getContentPane().add(gp);   // �н����� ����� �г��� ���̰� ��
				mainThread.interrupt();
				mp.count = 0;
				this.validate();
				repaint(); // �ٽ�ĥ�ϱ�
				mp.start = 0;  // ȭ�� ��ȯ��

		}
			if(mp.soloStart == 1) {	  // �����гο��� �н����� ����� ��ư�� Ŭ���ϸ� �Ͼ�� �̺�Ʈ 
				this.getContentPane().remove(mp);  // �����г��� ������ �ʰ� �ϰ�
				this.getContentPane().add(SP);   // �н����� ����� �г��� ���̰� ��
				mainThread.interrupt();
				mp.count = 0;
				this.validate();
				repaint(); // �ٽ�ĥ�ϱ�
				mp.soloStart = 0;  // ȭ�� ��ȯ��

		}
			if(gp.back == 1) {	  // �����гο��� �н����� ����� ��ư�� Ŭ���ϸ� �Ͼ�� �̺�Ʈ 
				this.getContentPane().remove(gp);  // �����г��� ������ �ʰ� �ϰ�
				this.getContentPane().add(mp);   // �н����� ����� �г��� ���̰� ��
				mainThread = mp.threadMake();
				mp.count = 12;
				mainThread.start();
				this.validate();
				repaint(); // �ٽ�ĥ�ϱ�
				gp.back = 0;  // ȭ�� ��ȯ��
			}
			if(SP.back == 1) {	  // �����гο��� �н����� ����� ��ư�� Ŭ���ϸ� �Ͼ�� �̺�Ʈ 
				this.getContentPane().remove(SP);  // �����г��� ������ �ʰ� �ϰ�
				this.getContentPane().add(mp);   // �н����� ����� �г��� ���̰� ��
				mainThread = mp.threadMake();
				mp.count = 12;
				mainThread.start();
				this.validate();
				repaint(); // �ٽ�ĥ�ϱ�
				SP.back = 0;  // ȭ�� ��ȯ��
			}
			try {Thread.sleep(500);
		}catch(Exception e) {}
	}
}


	
}
